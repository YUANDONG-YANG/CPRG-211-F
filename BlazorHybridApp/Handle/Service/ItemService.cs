using BlazorHybridApp.Handle.Exception;
using BlazorHybridApp.Handle.Models;
using BlazorHybridApp.Handle.Tool;
namespace BlazorHybridApp.Handle.Services;


public interface IItemService
{
    Task<Boolean> AddItem(string title);
    Task<Dictionary<bool, List<Item>>> GetAllItems();
    Task<Boolean> DeleteItem(int id);
    Task<bool> UpdateItemIsDone(int id, bool isDone);
}

public class ItemService : IItemService
{
    private readonly IItemsLoader _itemsLoader;
    private readonly IItemsSaver _itemsSaver;

    private int nextId = 1;

    public ItemService(IItemsLoader itemsLoader, IItemsSaver itemsSaver)
    {
        _itemsLoader = itemsLoader ?? throw new ArgumentNullException(nameof(itemsLoader));
        _itemsSaver = itemsSaver ?? throw new ArgumentNullException(nameof(itemsSaver));
    }

    public Task<Dictionary<bool, List<Item>>> GetAllItems()
    {
        List<Item> items = _itemsLoader.LoadItemsFromCsv();

        var groupedItems = items
            .GroupBy(item => item.IsDone)
            .ToDictionary(group => group.Key, group => group.ToList());

        return Task.FromResult(groupedItems);
    }

    public Item GetItemById(int id)
    {
        List<Item> items = _itemsLoader.LoadItemsFromCsv();
        return items.FirstOrDefault(x => x.Id == id);
    }

    public Task<Boolean> AddItem(string title)
    {
        List<Item> items = _itemsLoader.LoadItemsFromCsv();
        if (items.Any(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
        {
            throw new DuplicateItemException($"An item with title '{title}' already exists.");
        }
        items.Add(new Item(nextId++, title, false));
        Boolean isSave = _itemsSaver.SaveItemsIntoCsv(items);
        return Task.FromResult(isSave);
    }

    public Task<bool> DeleteItem(int id)
    {
        List<Item> items = _itemsLoader.LoadItemsFromCsv();
        var item = items.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            items.Remove(item);
            return Task.FromResult(_itemsSaver.SaveItemsIntoCsv(items));
        }
        return Task.FromResult(false);
    }

    public Task<bool> UpdateItemIsDone(int id, bool isDone)
    {
        List<Item> items = _itemsLoader.LoadItemsFromCsv();
        var item = items.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            item.IsDone = isDone;
            return Task.FromResult(_itemsSaver.SaveItemsIntoCsv(items));
        }
        return Task.FromResult(false);
    }
}

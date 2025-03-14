using System;

namespace BlazorHybridApp.Handle.Models
{
    public class Item
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }
        public static Item? Null { get; internal set; }

        public Item(int id, string title, bool isDone)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }

    }
}

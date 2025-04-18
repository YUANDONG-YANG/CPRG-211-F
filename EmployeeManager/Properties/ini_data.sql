-- PostgreSQL Database Script using CREATE OR REPLACE where applicable
-- Note: For tables, PostgreSQL doesn't support CREATE OR REPLACE TABLE directly
-- We'll use DROP IF EXISTS followed by CREATE for tables

-- Drop and recreate tables (in reverse order of dependencies)
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Wage;
DROP TABLE IF EXISTS Department;

-- Create Department table
CREATE TABLE Department (
    dept_id SERIAL PRIMARY KEY,
    dept_name VARCHAR(100) NOT NULL
);

-- Create Wage table
CREATE TABLE Wage (
    grade_id SERIAL PRIMARY KEY,
    grade_name VARCHAR(50) NOT NULL,
    base_wage DECIMAL(10, 2) NOT NULL CHECK (base_wage > 0),
    bonus_percent DECIMAL(5, 2) NOT NULL DEFAULT 0
);

-- Create Employee table
CREATE TABLE Employee (
    emp_id SERIAL PRIMARY KEY,
    dept_id INTEGER NOT NULL REFERENCES Department(dept_id),
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(100),
    grade_id INTEGER NOT NULL REFERENCES Wage(grade_id),
    hire_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fire_date TIMESTAMP NULL
);

-- Function to check if data exists before inserting
CREATE OR REPLACE FUNCTION insert_if_empty(table_name text, insertion_sql text) RETURNS void AS $$
DECLARE
    count_rows integer;
    dynamic_sql text;
BEGIN
    dynamic_sql := 'SELECT COUNT(*) FROM ' || table_name;
    EXECUTE dynamic_sql INTO count_rows;

    IF count_rows = 0 THEN
        EXECUTE insertion_sql;
    END IF;
END;
$$ LANGUAGE plpgsql;

-- Insert sample data for departments (only if empty)
SELECT insert_if_empty('Department', $sql$
    INSERT INTO Department (dept_name) VALUES
    ('Human Resources'),
    ('Finance'),
    ('Information Technology'),
    ('Marketing'),
    ('Operations'),
    ('Research and Development'),
    ('Sales'),
    ('Customer Service')
$sql$);

-- Insert sample data for wage grades (only if empty)
SELECT insert_if_empty('Wage', $sql$
    INSERT INTO Wage (grade_name, base_wage, bonus_percent) VALUES
    ('Entry Level', 3500.00, 5.00),
    ('Junior', 4500.00, 10.00),
    ('Intermediate', 6000.00, 15.00),
    ('Senior', 8000.00, 20.00),
    ('Team Lead', 10000.00, 25.00),
    ('Manager', 12000.00, 30.00),
    ('Director', 15000.00, 40.00),
    ('Executive', 20000.00, 50.00)
$sql$);

-- Insert sample employees (only if empty)
SELECT insert_if_empty('Employee', $sql$
    INSERT INTO Employee (dept_id, firstname, lastname, phone, email, grade_id) VALUES
    (3, 'John', 'Smith', '555-123-4567', 'john.smith@company.com', 3),
    (1, 'Sarah', 'Johnson', '555-234-5678', 'sarah.johnson@company.com', 2),
    (4, 'Michael', 'Brown', '555-345-6789', 'michael.brown@company.com', 4),
    (2, 'Jennifer', 'Williams', '555-456-7890', 'jennifer.williams@company.com', 5),
    (3, 'David', 'Jones', '555-567-8901', 'david.jones@company.com', 3),
    (7, 'Jessica', 'Miller', '555-678-9012', 'jessica.miller@company.com', 6),
    (5, 'James', 'Davis', '555-789-0123', 'james.davis@company.com', 4),
    (6, 'Lisa', 'Garcia', '555-890-1234', 'lisa.garcia@company.com', 7),
    (3, 'Robert', 'Rodriguez', '555-901-2345', 'robert.rodriguez@company.com', 3),
    (1, 'Emily', 'Wilson', '555-012-3456', 'emily.wilson@company.com', 2)
$sql$);

-- Optional: Create or replace a view for employee details
CREATE OR REPLACE VIEW employee_details AS
SELECT
    e.emp_id,
    e.firstname,
    e.lastname,
    e.phone,
    e.email,
    e.hire_date,
    e.fire_date,
    d.dept_id,
    d.dept_name,
    w.grade_id,
    w.grade_name,
    w.base_wage,
    w.bonus_percent
FROM
    Employee e
    JOIN Department d ON e.dept_id = d.dept_id
    JOIN Wage w ON e.grade_id = w.grade_id;

-- Optional: Create or replace function to calculate total wage
CREATE OR REPLACE FUNCTION calculate_total_wage(emp_id INTEGER)
RETURNS DECIMAL AS $$
DECLARE
    base DECIMAL;
    bonus_pct DECIMAL;
    total DECIMAL;
BEGIN
    SELECT
        w.base_wage,
        w.bonus_percent
    INTO
        base,
        bonus_pct
    FROM
        Employee e
        JOIN Wage w ON e.grade_id = w.grade_id
    WHERE
        e.emp_id = $1;

    total := base + (base * bonus_pct / 100);
    RETURN total;
END;
$$ LANGUAGE plpgsql;

-- Clean up the helper function if desired
DROP FUNCTION IF EXISTS insert_if_empty;
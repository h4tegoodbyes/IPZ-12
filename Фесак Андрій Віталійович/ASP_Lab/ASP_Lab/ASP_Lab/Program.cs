using System.Diagnostics;
using ASP_Lab;
using Lab_2;

//___________________________________________________________________________________
//Задання даних для обробки
var interval = new Stopwatch();
Random ran = new Random();
int size;
Console.WriteLine("Введiть розмiр для контейнерiв");
try
{
    size = int.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
int[] arr = new int [size];
LinkedList<int> list = new LinkedList<int>();
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = ran.Next(9999);
    list.AddLast(arr[i]);
    Console.Write($"{arr[i]} ");
}

Console.WriteLine("\nВведiть цiле число для пошуку");
int number;
try
{
    number = int.Parse(Console.ReadLine());
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

Console.WriteLine("_________________________________________________________________________");
//___________________________________________________________________________________
//Лінійний пошук
//Повинен повернути індекс шуканого значення, або -1 у випадку відсутності значення.
//____Масив___
interval.Reset();
interval.Start();
int index = Search.Linear_Search(arr, number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат лiнiйного пошуку в масивi {index}");
}
//____Ліст___
interval.Start();
index = Search.Linear_Search(list, number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат лiнiйного пошуку в зв'язному списку {index}");
}
Console.WriteLine("_________________________________________________________________________");
//___________________________________________________________________________________
//Пошук з бар'єром
//Повертає індекс елемента, або значення, яке на 1 більше за розмір контейнера
int[] new_arr = new int[size+1];
for (int i = 0; i < size; i++)
{
    new_arr[i] = arr[i];
}
new_arr[size] = number;
list.AddLast(number);
//____Масив___
interval.Start();
index = Search.Barrier_Search(new_arr,number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index>size)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат пошуку з бар'єром в масивi {index}");
}

//____Ліст___
interval.Start();
index = Search.Barrier_Search(list,number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index>size)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат пошуку з бар'єром в зв'язному списку {index}");
}

list.Remove(list.Count - 1);
Console.WriteLine("_________________________________________________________________________");
//___________________________________________________________________________________
//Пошук бінарний
//Повертає індекс елемента, або -1
list.OrderBy(number=>number);
QuickSort.Sort(arr, 0,arr.Length-1);
for (int i = 0; i < arr.Length; i++)
{
    Console.Write($"{arr[i]} ");
}
interval.Start();
index = Search.Binary_Search(arr,0,arr.Length-1,number);
interval.Stop();
Console.WriteLine($"\nЧас: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат бiнарного пошуку в масивi {index}");
}
//____Ліст___
list.OrderBy(number=>number);
interval.Start();
index = Search.Binary_Search(list,0,list.Count,number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат бiнарного пошуку в зв'язному списку {index}");
}
Console.WriteLine("_________________________________________________________________________");
//___________________________________________________________________________________
//Пошук бінарний модифікований
//Повертає індекс елемента, або -1
interval.Reset();
interval.Start();
index = Search.Binary_Search_Modify(arr,0,arr.Length-1,number);
interval.Stop();
Console.WriteLine($"\nЧас: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення не знайдено");
}
else
{
    Console.WriteLine($"Результат модифiкованого бiнарного пошуку в масивi {index}");
}
//___________________________________________________________________________________
interval.Reset();
interval.Start();
index = Search.Binary_Search_Modify(list,0,list.Count,number);
interval.Stop();
Console.WriteLine($"Час: {interval.Elapsed}");
interval.Reset();
if (index == -1)
{
    Console.WriteLine("Значення модифiкованого не знайдено");
}
else
{
    Console.WriteLine($"Результат модифiкованого бiнарного пошуку в зв'язному списку {index}");
}
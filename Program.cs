
using Tutorial3.containers;
using Tutorial3.enums;
using Tutorial3.exceptions;
using Tutorial3.vehicles;

// Create containers of a given type
var liquidContainer1 = new LiquidContainer(300, 200, 100, 2000, false);
var gasContainer1 = new GasContainer(300, 200, 100, 5000, 10);
var refrigeratedContainer1 = new RefrigeratedContainer(300, 200, 100, 2000, ProductType.Fish, 3);

var liquidContainer2 = new LiquidContainer(300, 200, 100, 1000, true);
var gasContainer2 = new GasContainer(300, 200, 100, 3000, 20);
var refrigeratedContainer2 = new RefrigeratedContainer(300, 200, 100, 1500, ProductType.Bananas, 15);


// Create ships
var ship1 = new Ship(15, 10, 10);
var ship2 = new Ship(20, 5, 5);


// Load cargo into containers
liquidContainer1.Load(1000);
gasContainer1.Load(2500);
refrigeratedContainer1.Load(2000);

liquidContainer2.Load(450);
gasContainer2.Load(2000);
refrigeratedContainer2.Load(1500);


// Load containers onto a ship
ship1.AddContainer(liquidContainer1);
ship1.AddContainer(gasContainer1);
ship1.AddContainer(refrigeratedContainer1);


// Load a list of containers onto a ship
var specialContainers = new List<Container>();
specialContainers.Add(liquidContainer2);
specialContainers.Add(gasContainer2);
specialContainers.Add(refrigeratedContainer2);
ship2.AddContainers(specialContainers);


// Remove containers from the ship
ship1.RemoveContainer(gasContainer1);
ship2.RemoveContainer(liquidContainer2);


// Unload containers
gasContainer1.Unload();
liquidContainer2.Unload();


// Replace a container on the ship with a given number with another container
ship1.ReplaceContainer(1, liquidContainer2);


// Transferring a container between two ships
Vehicle.TransferContainer(liquidContainer2, ship1, ship2);


// Print information about a given container
Console.WriteLine(liquidContainer1);
Console.WriteLine();
Console.WriteLine(gasContainer1);
Console.WriteLine();


// Print information about a given ship and its cargo
Console.WriteLine(ship1);
Console.WriteLine();
Console.WriteLine(ship2);
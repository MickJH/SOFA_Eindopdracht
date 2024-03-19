// Create a new sprint
using AvansDevOps.State.BacklogItems;
using AvansDevOps.State.Sprints;

Sprint sprint = new Sprint("Initial Sprint", DateTime.Now, DateTime.Now.AddDays(14));
Console.WriteLine($"Sprint created: {sprint.Name}");

// Attempt to change the name of the sprint while it's in the CreatedState
try
{
    sprint.SetName("Updated Sprint Name");
    Console.WriteLine($"Sprint name changed to: {sprint.Name}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error changing name: {ex.Message}");
}

// Start the sprint
sprint.Start();
Console.WriteLine("Sprint started.");

// Attempt to change the name of the sprint after it has started
try
{
    sprint.SetName("Attempted Name Change After Start");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error changing name after start: {ex.Message}");
}


using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0027;
using R5T.D0027.Default;

using R5T.Dacia;


namespace R5T.Darbi
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = Console.Out;
            
            // No initial blank line.
            var systemEnvironmentMachineNamePropertyName = "System.Environment.MachineName";
            writer.WriteLine($"{Constants.ProgramName}: Script providing the machine name as .NET would see it, using the {systemEnvironmentMachineNamePropertyName} value.");
            writer.WriteLine();

            var services = new ServiceCollection();
            
            var machineNameProviderAction = services.AddMachineNameProviderAction();

            services
                .Run(machineNameProviderAction)
                ;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var machineNameProvider = serviceProvider.GetRequiredService<IMachineNameProvider>();

                var machineName = machineNameProvider.GetMachineName();

                writer.WriteLine();
                writer.WriteLine($"Machine name: {machineName}");
            }

            Console.WriteLine(); // Blank.
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}

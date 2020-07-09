using System;
using System.IO;
using System.Threading.Tasks;

namespace Desk_Cleaner
{
    internal class EventHandler
    {
        public static bool setState;
        public static Extensions extensions = new Extensions();

        public static void On_modified(string watchpath, string destination_path)
        {
            try
            {
                destination_path = Edit_Path.Add_date_to_path(Path.GetDirectoryName(destination_path));
                Parallel.ForEach(Directory.EnumerateFiles(watchpath), (child, state) =>
                {
                    try
                    {
                        if (!setState)
                        {
                            state.Break();
                        }

                        if (File.Exists(child) && (extensions.extension_paths.ContainsKey(Path.GetExtension(child))))
                        {
                            //destination_path = $"{destination_path}{Path.GetExtension(child)}";
                            Directory.Move(child, Edit_Path.Rename_file(child, destination_path));
                            //destination_path = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"EventHandler.Extensions.On_modified.Parallel: Exception [{ex}] thrown, <[{ex.Message}]>.");
                        state.Break();
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EventHandler.Extensions.On_modified: Exception [{ex}] thrown, <[{ex.Message}]>.");
            }
        }
    }
}
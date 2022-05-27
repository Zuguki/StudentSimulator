using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UnityEngine;

namespace DefaultNamespace
{
    public static class EnvironmentSerializer
    {
        private static void WriteItemsDown()
        {
            using var fs = new FileStream("serialize.json", FileMode.CreateNew);
            
            JsonSerializer.Serialize(fs, PlayerStats.Items);
            Debug.Log("Saved");
        }

        private static List<Type> GetItemsFrom()
        {
            using var fs = new FileStream("serialize.json", FileMode.Open);

            return JsonSerializer.Deserialize<List<Type>>(fs);
        }
    }
}
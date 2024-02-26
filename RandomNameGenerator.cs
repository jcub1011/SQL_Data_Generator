using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SQL_Data_Generator;

public static class RandomNameGenerator
{
    static List<string> _names = new();
    static Random _rand = new();

    /// <summary>
    /// Returns (firstName, lastName)
    /// </summary>
    /// <returns></returns>
    static public (string first, string last) GetName()
    {
        return ("Dave", "Duncan");
    }
}

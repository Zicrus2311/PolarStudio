﻿using System.Diagnostics;

namespace PolarStudio;

public static class WebUtilities {
    public static void OpenWebsite(string url) {
        var psi = new ProcessStartInfo {
            FileName = url,
            UseShellExecute = true
        };
        Process.Start(psi);
    }
}
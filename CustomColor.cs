using CorrosiveCobra;

namespace Sorwest.CorrosiveCobra
{
    public static class CustomColor
    {
        private static bool CobraLookupColor(ref uint? __result, string key)
        {
            if (key == "Sorwest.CorrosiveCobra.CobraDeck")
            {
                __result = ToInt(Manifest.CorrosiveCobraColor);
                return false;
            }
            return true;
        }

        private static uint ToInt(System.Drawing.Color color)
        {
            return (uint)((Mutil.Clamp((int)(color.A), 0, 255) << 24) | (Mutil.Clamp((int)(color.R), 0, 255) << 16) | (Mutil.Clamp((int)(color.G), 0, 255) << 8) | Mutil.Clamp((int)(color.B), 0, 255));
        }
    }
}

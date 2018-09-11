void Render(Surface dst, Surface src, Rectangle rect)
{
    ColorBgra PrimaryColor = EnvironmentParameters.PrimaryColor;
    ColorBgra SecondaryColor = EnvironmentParameters.SecondaryColor;

    ColorBgra CurrentPixel;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        if (IsCancelRequested) return;
        for (int x = rect.Left; x < rect.Right; x++)
        {
            CurrentPixel = src[x,y];
            double alpha = 0;
            double PrimaryChannels = ((double) PrimaryColor.R + (double) PrimaryColor.G + (double) PrimaryColor.B)/765;
            double SecondaryChannels = ((double) SecondaryColor.R + (double) SecondaryColor.G + (double) SecondaryColor.B)/765;
            double CurrentChannels = ((double) CurrentPixel.R + (double) CurrentPixel.G + (double) CurrentPixel.B)/765;
            
            Debug.WriteLine("");
            
            if (PrimaryChannels - SecondaryChannels == 0 || CurrentPixel.A == 0)
            {
                alpha = 0;
            } 
            else
            {
                alpha = 255 * Math.Abs(CurrentChannels - SecondaryChannels)/Math.Abs(PrimaryChannels - SecondaryChannels);
            }
            
            CurrentPixel.A = (byte) alpha;
            CurrentPixel.R = PrimaryColor.R;
            CurrentPixel.G = PrimaryColor.G;
            CurrentPixel.B = PrimaryColor.B;
            dst[x,y] = CurrentPixel;
        }
    }
}

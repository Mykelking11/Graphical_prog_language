using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_prog_language.Interface
{
    public interface IMockGraphics
    {
        void DrawEllipse(Pen pen, int x, int y, int width, int height);
    }
}
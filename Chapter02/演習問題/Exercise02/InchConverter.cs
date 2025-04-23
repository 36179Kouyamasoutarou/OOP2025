using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    static class IntchConverter {

        const double ratio = 0.0254;

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }
        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * ratio;
        }
    }
}
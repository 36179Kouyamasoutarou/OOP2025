using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public abstract class ConverterBase {

        // このクラスを継承して具体的な単位変換を実装する

        public abstract bool IsMyUnit(string name);
        // メートルとの比率(この比率を掛けるとメートルに変換できる)
        protected abstract double Ratio { get; }
        // 距離の単位名(例えば、"メートル", "フィートなど")
        public abstract string UnitName { get; }

        // メートルから特定単位に変換
        public double FromMeter(double meter) => meter / Ratio;
        // 特定単位からメートルに変換
        public double ToMeter(double value) => value * Ratio;
    }
}
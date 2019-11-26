using System;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using Microsoft.ML.Trainers;
namespace Wine_Predictor
{
    public class wineAttributes
    {
        [Column("0")]
        public string Label;
        [Column("1")]
        public float alcohol;
        [Column("2")]
        public float malicAcid;
        [Column("3")]
        public float ash;
        [Column("4")]
        public float alcalinity;
        [Column("5")]
        public float magnesium;
        [Column("6")]
        public float totalPhenols;
        [Column("7")]
        public float flavanoids;
        [Column("8")]
        public float nonFlavanoidPhenols;
        [Column("9")]
        public float proanthocyanins;
        [Column("10")]
        public float colourIntensity;
        [Column("11")]
        public float hue;
        [Column("12")]
        public float odOfDilutedWines;
        [Column("13")]
        public float proline;
    }
    public class winePredictor
    {
        [ColumnName("PredictedLabel")]
        public string predictedLabels;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new LearningPipeline();
            string datapath = @"C:\Users\LegendDude\Desktop\wine.data";
            pipeline.Add(new TextLoader(datapath).CreateFrom<wineAttributes>(separator: ','));
            pipeline.Add(new Dictionarizer("Label"));
            pipeline.Add(new ColumnConcatenator("Features", "alcohol", "malicAcid", "ash", "alcalinity", "magnesium", "totalPhenols", "flavanoids", "nonFlavanoidPhenols", "proanthocyanins", "colourIntensity", "hue", "odOfDilutedWines", "proline"));
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() {PredictedLabelColumn = "PredictedLabel"});
            var model = pipeline.Train<wineAttributes, winePredictor>();
             var prediction = model.Predict(new wineAttributes()
             {
                 alcohol =14.15f,
                 malicAcid = 4.1f,
                 ash = 2.74f,
                 alcalinity = 24.5f,
                 magnesium =  96f,
                 totalPhenols = 2.05f,
                 flavanoids = .76f,
                 nonFlavanoidPhenols = .56f,
                 proanthocyanins =  1.35f,
                 colourIntensity =  9.2f,
                 hue = .61f,
                 odOfDilutedWines = 1.6f,
                 proline = 560f
             }); 
             Console.WriteLine($"Predicted wine is: {prediction.predictedLabels}");
             Console.ReadKey(); 
        }
    }
}
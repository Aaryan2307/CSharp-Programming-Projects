using System;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using Microsoft.ML.Trainers;

namespace Machine_Learning_CSharp
{
   public class irisData
    {
        [Column("0")]
        public float sepalLength;
        [Column("1")]
        public float sepalWidth;
        [Column("2")]
        public float petalLength;
        [Column("3")]
        public float petalWidth;
        [Column("4")]
        public string Label;
    }
    public class irisPrediction
    {
        [ColumnName("PredictedLabel")]
        public string predictedLabels;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new LearningPipeline();
            string datapath = "iris.data";
            pipeline.Add(new TextLoader(datapath).CreateFrom<irisData>(separator: ','));
            pipeline.Add(new Dictionarizer("Label"));
            pipeline.Add(new ColumnConcatenator("Features" , "sepalLength", "sepalWidth", "petalLength", "petalWidth"));
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel"});
            var model = pipeline.Train<irisData, irisPrediction>();
            var prediction = model.Predict(new irisData()
            {
                sepalLength = 6.3f,
                sepalWidth = 2.6f,
                petalLength = 1.2f,
                petalWidth = 0.2f
            });
            Console.WriteLine($"Predicted flower is: {prediction.predictedLabels}");
            Console.ReadKey();
        }
    }
}

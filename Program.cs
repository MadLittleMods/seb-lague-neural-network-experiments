// Top-level statements (TLS) allows us to do away with the namespace/class/Main
// boilerplate. See https://aka.ms/new-console-template for more information.

int numberOfLabels = Enum.GetNames(typeof(Label)).Length;

// This is a small testing dataset (to make sure our code is working) with only 2
// arbitrary features (x and y) where the labeled data points (fish and goat) occupy
// distinct parts of the graph. The boundary between the two labels is not a
// straight line (linear relationship) so we need the power of a neural network to
// learn the non-linear relationship.
//
// Graph of animal data points:
// https://www.desmos.com/calculator/tkfacez5wt
DataPoint[] trainingData = {
	new DataPoint(new double[] { 0.924, 0.166 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.04, 0.085 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.352, 0.373 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.662, 0.737 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.724, 0.049 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.123, 0.517 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.2245, 0.661 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.466, 0.504 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.375, 0.316 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.039, 0.3475 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.28, 0.363 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.342, 0.142 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.517, 0.416 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.108, 0.403 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.728, 0.208 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.214, 0.238 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.865, 0.525 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.645, 0.363 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.436, 0.182 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.41, 0.085 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.146, 0.404 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.09, 0.457 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.663, 0.61 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.445, 0.384 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.588, 0.409 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.49, 0.075 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.679, 0.4455 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.145, 0.159 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.086, 0.155 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.192, 0.348 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.766, 0.62 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.132, 0.28 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.04, 0.403 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.588, 0.353 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.59, 0.452 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.364, 0.042 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.863, 0.068 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.806, 0.274 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.571, 0.49 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.762, 0.39 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.245, 0.388 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.097, 0.05 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.112, 0.339 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.538, 0.51 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.73, 0.507 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.472, 0.604 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.368, 0.506 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.768, 0.14 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.49, 0.75 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.21, 0.573 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.881, 0.382 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.331, 0.263 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.6515, 0.213 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.155, 0.721 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.89, 0.746 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.613, 0.265 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.442, 0.449 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.064, 0.554 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.314, 0.771 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.673, 0.135 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.535, 0.216 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.047, 0.267 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.502, 0.324 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.096, 0.827 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.586, 0.653 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.214, 0.049 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.683, 0.88 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.246, 0.315 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.264, 0.512 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.39, 0.414 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.323, 0.573 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.593, 0.307 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.314, 0.692 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.817, 0.456 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.596, 0.054 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.192, 0.403 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.195, 0.469 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.587, 0.138 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.315, 0.338 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.917, 0.267 }, (int) Label.Goat, numberOfLabels),
};


DataPoint[] testingPoints = {
	new DataPoint(new double[] { 0.23, 0.14 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.087, 0.236 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.507, 0.142 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.503, 0.403 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.67, 0.076 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.074, 0.34 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.41, 0.257 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.278, 0.273 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.5065, 0.373 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.5065, 0.272 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.551, 0.173 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.636, 0.128 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.2, 0.33 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.409, 0.345 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.358, 0.284 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.098, 0.102 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.442, 0.058 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.368, 0.167 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.459, 0.3235 }, (int) Label.Fish, numberOfLabels),
	new DataPoint(new double[] { 0.37, 0.674 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.32, 0.43 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.066, 0.628 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.635, 0.527 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.704, 0.305 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.82, 0.137 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.862, 0.305 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.709, 0.679 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.18, 0.527 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.072, 0.405 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.218, 0.408 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.303, 0.357 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.425, 0.443 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.554, 0.505 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.659, 0.251 }, (int) Label.Goat, numberOfLabels),
	new DataPoint(new double[] { 0.597, 0.386 }, (int) Label.Goat, numberOfLabels),
};


var hyperParameters = new HyperParameters();
hyperParameters.layerSizes = new int[] {
	2,
	//10, 10,
	numberOfLabels,
};
hyperParameters.activationType = Activation.ActivationType.ReLU;
hyperParameters.outputActivationType = Activation.ActivationType.Softmax;
hyperParameters.costType = Cost.CostType.MeanSquaredError;
hyperParameters.initialLearningRate = 0.1;
hyperParameters.learnRateDecay = 0.0;
hyperParameters.minibatchSize = 1;
hyperParameters.momentum = 0.3;
hyperParameters.regularization = 0.0;

var neuralNetwork = new NeuralNetwork(hyperParameters.layerSizes);
var activation = Activation.GetActivationFromType(hyperParameters.activationType);
var outputLayerActivation = Activation.GetActivationFromType(hyperParameters.outputActivationType);
neuralNetwork.SetActivationFunction(activation, outputLayerActivation);
neuralNetwork.SetCostFunction(Cost.GetCostFromType(hyperParameters.costType));

// Match the random weights and biases from our Zig version
neuralNetwork.layers[0].weights = new double[] { 0.3251169104168574, 1.0577112895890197, 0.36170159819321346, 0.014072284781826894, -1.271551261654049, 0.32522080597322767 };
neuralNetwork.layers[0].biases = new double[] { 0.1, 0.1, 0.1 };

Console.WriteLine("Starting training!");
var trainingBatches = DataSetHelper.CreateMiniBatches(trainingData, hyperParameters.minibatchSize, false);
var currentEpochIterationCount = 0;
while (
//true
currentEpochIterationCount < 1
)
{
	for (int batchIndex = 0; batchIndex < trainingBatches.Length; batchIndex += 1)
	{
		var trainingBatch = trainingBatches[batchIndex];
		neuralNetwork.Learn(
			trainingBatch.data,
			hyperParameters.initialLearningRate,
			hyperParameters.regularization,
			hyperParameters.momentum
		);

		//if (currentEpochIterationCount % 1 == 0 && currentEpochIterationCount != 0) {
		var cost = CostMany(testingPoints);
		Console.WriteLine($"epoch: {currentEpochIterationCount} batch {batchIndex} -> cost {cost}");
		//}

		// TODO: Remove
		break;
	}

	// Shuffle the data after each epoch
	DataSetHelper.ShuffleBatches(trainingBatches);

	currentEpochIterationCount += 1;
}


double CostIndividual(DataPoint dataPoint)
{
	var predictedOutputs = neuralNetwork.CalculateOutputs(dataPoint.inputs);
	var cost = neuralNetwork.cost.CostFunction(predictedOutputs, dataPoint.expectedOutputs);
	return cost;
}

double CostMany(DataPoint[] dataPoints)
{
	double cost_sum = 0.0;
	for (var i = 0; i < dataPoints.Length; i++)
	{
		var dataPoint = dataPoints[i];
		var cost = CostIndividual(dataPoint);
		cost_sum += cost;
	}

	return cost_sum;
}



enum Label : int
{
	Fish,
	Goat,
	RandomThirdLabel,
}

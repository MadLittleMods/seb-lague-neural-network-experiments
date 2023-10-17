// See https://aka.ms/new-console-template for more information
// Top-level statements (TLS) allows us to do away with the namespace/class/Main boilerplate


int numberOfLabels = Enum.GetNames(typeof(Label)).Length;

var hyperParameters = new HyperParameters();
hyperParameters.layerSizes = new int[] {
	2,
	//10, 10,
	numberOfLabels,
};
hyperParameters.activationType = Activation.ActivationType.LeakyReLU;
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

Console.WriteLine("Starting training!");
var currentEpochIterationCount = 0;
while (currentEpochIterationCount < 100)
{
	DataPoint[] trainingBatch = {
		new DataPoint(new double[] {0.5, 0.5}, (int) Label.Fish, numberOfLabels),
	};

	neuralNetwork.Learn(
		trainingBatch,
		hyperParameters.initialLearningRate,
		hyperParameters.regularization,
		hyperParameters.momentum
	);

	//if (currentEpochIterationCount % 1 == 0 && currentEpochIterationCount != 0) {
	var cost = CostMany(trainingBatch);
	Console.WriteLine($"epoch: {currentEpochIterationCount} -> cost {cost}");
	//}

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
}

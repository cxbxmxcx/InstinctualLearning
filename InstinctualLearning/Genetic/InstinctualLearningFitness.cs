using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InstinctualLearning
{
    public class InstinctualLearningFitness<Environment> : IFitness where Environment : IEnvironment
    {        
        public InstinctualLearningFitness(params InstinctualLearningInput[] inputs)
        {
            m_inputs = inputs;
            var parametersCount = m_inputs[0].Arguments.Count;
            AvailableOperations = InstinctualLearningChromosome.BuildAvailableOperations(parametersCount);
            m_parameterNames = InstinctualLearningChromosome.GetParameterNames(parametersCount);
        }

        public ReadOnlyCollection<string> AvailableOperations { get; internal set; }

        private string[] m_parameterNames;
        private InstinctualLearningInput[] m_inputs;

        public double Evaluate(IChromosome chromosome)
        {
            var c = chromosome as InstinctualLearningChromosome;
            var function = c.BuildFunction();

            var fitness = 0.0;
            var episodes = 100;
            var reward = 0.0;
            var pain = -1.0 / episodes;

            var action = function.Substring(0, function.Length / 2);
            var memory = function.Substring(function.Length / 2);

            var mem = 0.0;
            var act = 0.0;
            var exp = 0.0;

            var inputs = new Dictionary<string, double>();
            var environment = (IEnvironment)Activator.CreateInstance(typeof(Environment));

            //var r = new Random();
            //((GridWorldEnvironment)environment).size = 4; // r.Next(3, 10);

            foreach (var name in m_parameterNames)
            {
                inputs.Add(name, 0.0);
            }
            string path = string.Empty;
            try
            {
                for (int i = 0; i < episodes; i++)
                {
                    var state = environment.State;
                    if (state == 16)
                    {
                        path += " " + "goal";                            
                        break;
                    }
                    
                    inputs["A"] = state;
                    inputs["B"] = mem;
                    inputs["C"] = act;
                    reward += (-1.0 / episodes);
                    
                   
                    act = (int)GetFunctionResult(action, inputs);                    
                    inputs["C"] = act;
                    environment.Act(act);
                    //update memory
                    mem = GetFunctionResult(memory, inputs);
                    path += " " + state.ToString() + "[" + act.ToString() + "]";
                }
                reward += environment.ExpectedReward;
            }
            catch (Exception ex)
            {
                return double.MinValue;
            }

            //foreach (var input in m_inputs)
            //{
            //    try
            //    {
            //        var result = GetFunctionResult(function, input);
            //        var diff = Math.Abs(result - input.ExpectedResult);

            //        fitness += diff;
            //    }
            //    catch (Exception ex)
            //    {
            //        return double.MinValue;
            //    }
            //}
            if (reward > InstinctualLearningChromosome.BestReward)
            {
                InstinctualLearningChromosome.BestReward = reward;
                InstinctualLearningChromosome.Best = path;
            }

            return reward-1;
        }

        private string ConvertFunction(string function)
        {
            if (function.Contains("if"))
            {
                var idx = function.IndexOf("if");
                if(idx > function.Length-3)
                {
                    function = function.Replace("if", "");
                }

            }
            return function;
        }

        public double GetFunctionResult(string function, Dictionary<string,double> inputs)
        {
            var expression = new NCalc.Expression(function);

            foreach(var input in inputs)
            {
                expression.Parameters.Add(input.Key, input.Value);
            }

            //for (int i = 0; i < inputs.Count; i++)
            //{
                
            //    expression.Parameters.Add(m_parameterNames[i], inputs);
            //}

            var result = expression.Evaluate();

            return (double)result;
        }

        /// <summary>
        /// Gets the function result.
        /// </summary>
        /// <returns>The function result.</returns>
        /// <param name="function">The function.</param>
        /// <param name="input">The arguments values and expected results of the function.</param>
        public double GetFunctionResult(string function, InstinctualLearningInput input)
        {
            //var func = Parser<DoubleEvaluator>.Parse(function);

            //var ctx = new VariableContext<DoubleEvaluator>();
            //var vars = "ABCDEFGH";
            //for(int i = 0;i<input.Arguments.Count;i++)
            //{
            //    ctx.AddVariable(vars.Substring(i, 1), input.Arguments[i]);
            //}

            //var result = func.Eval(ctx);
            var expression = new NCalc.Expression(function);

            for (int i = 0; i < m_parameterNames.Length; i++)
            {
                expression.Parameters.Add(m_parameterNames[i], input.Arguments[i]);
            }

            var result = expression.Evaluate();

            return (double)result;

            //return result.Result;
           // return 0.0;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniClass {

    public class Eval {

        public Eval() {
            //CallByExcel("Test(name=Zano,name2=Zano2)");
            //Call(this, "Test", "Zano", "Zano2");
            //List<string> methodNames = GetMethodNames(typeof(Eval));


            //วิธีการใช้ Eval แบบวนลูป
            //functionList.Add(() => Test("Z1", "hello"));
            //CallList();
        }

        /// <summary>
        /// แอดฟังก์ชั่นกับพารามิเตอร์เข้ามาในนี้ แล้วตามด้วย CallList
        /// </summary>
        public List<Action> functionList = new List<Action>();

        /// <summary>
        /// เรียกใช้ฟังก์ชั่นนี้เพิ่อวนลูป call ฟังก์ชั่นใน list ให้ครบ
        /// </summary>
        public void CallList() {
            foreach (var function in functionList)
            {
                function.Invoke();
            }
        }


        /// <summary>
        /// A method that takes two string parameters and shows them in a message box
        /// </summary>
        /// <param name="name">The first string parameter</param>
        /// <param name="name2">The second string parameter</param>
        public void Test(string name, string name2) {
            MessageBox.Show(name + name2);
        }


        /// <summary>
        /// Parses and invokes a method based on a string representation of a function call.
        /// </summary>
        /// <param name="function">A string representing the function call in the format "functionName(parameter1=value1, parameter2=value2, ...)"</param>
        public void CallByExcel(string function) {
            // Initialize variables to store function name and parameter values
            string nameFunction = string.Empty; // The name of the function to call
            List<string> parameterList = new List<string>(); // A list of parameter values

            // Extract function name from the function string
            for (int i = 0; i < function.Length; i++)
            {
                if (function[i] == '(')
                {
                    break;
                }
                nameFunction += function[i];
            }

            // Extract parameters from the function string
            int startIndex = function.IndexOf('(') + 1;
            int endIndex = function.IndexOf(')');
            string parametersString = function.Substring(startIndex, endIndex - startIndex);

            // If there are parameters, extract and add their values to the parameter list
            if (!string.IsNullOrEmpty(parametersString))
            {
                string[] parameters = parametersString.Split(',');
                foreach (string parameter in parameters)
                {
                    string trimmedParameter = parameter.Trim();
                    int equalsIndex = trimmedParameter.IndexOf('=');
                    if (equalsIndex >= 0)
                    {
                        string parameterValue = trimmedParameter.Substring(equalsIndex + 1).Trim();
                        parameterList.Add(parameterValue);
                    }
                    else
                    {
                        parameterList.Add(trimmedParameter);
                    }
                }
            }

            // Invoke the method with the extracted function name and parameter values
            try
            {
                MethodInfo mi = this.GetType().GetMethod(nameFunction);
                object[] parametersArray = parameterList.ToArray<object>();
                mi.Invoke(this, parametersArray);
            } catch (Exception ex)
            {
                MessageBox.Show("Function Error: " + ex.Message);
            }
        }


        /// <summary>
        /// Calls a method on an instance of an object, passing in any required parameters
        /// </summary>
        /// <param name="myClass">The instance of the object on which the method will be called</param>
        /// <param name="functionName">The name of the method to be called</param>
        /// <param name="parameters">Any required parameters for the method being called</param>
        public void Call(object myClass, string functionName, params object[] parameters) {
            try
            {
                // Get the method to be called from the object's type using reflection
                MethodInfo mi = myClass.GetType().GetMethod(functionName);

                // Create an object array from the parameters array
                object[] parametersArray = parameters;

                // Call the method on the object instance with the parameters provided
                mi.Invoke(myClass, parametersArray);

            } catch (Exception)
            {
                MessageBox.Show("Function Error: [" + functionName + "]");
                return;
            }
        }


        /// <summary>
        /// Gets a list of the names of all non-special public instance methods declared in the specified type.
        /// </summary>
        /// <param name="type">The type to retrieve the method names from.</param>
        /// <returns>A list of method names.</returns>
        public static List<string> GetMethodNames(Type type) {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                       .Where(m => !m.IsSpecialName)
                       .Select(m => m.Name)
                       .ToList();
        }

    }
}

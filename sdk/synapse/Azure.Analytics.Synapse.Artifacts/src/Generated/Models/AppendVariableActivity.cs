// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> Append value for a Variable of type Array. </summary>
    public partial class AppendVariableActivity : ControlActivity
    {
        /// <summary> Initializes a new instance of AppendVariableActivity. </summary>
        /// <param name="name"> Activity name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public AppendVariableActivity(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Type = "AppendVariable";
        }

        /// <summary> Initializes a new instance of AppendVariableActivity. </summary>
        /// <param name="name"> Activity name. </param>
        /// <param name="type"> Type of activity. </param>
        /// <param name="description"> Activity description. </param>
        /// <param name="dependsOn"> Activity depends on condition. </param>
        /// <param name="userProperties"> Activity user properties. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="variableName"> Name of the variable whose value needs to be appended to. </param>
        /// <param name="value"> Value to be appended. Could be a static value or Expression. </param>
        internal AppendVariableActivity(string name, string type, string description, IList<ActivityDependency> dependsOn, IList<UserProperty> userProperties, IDictionary<string, object> additionalProperties, string variableName, object value) : base(name, type, description, dependsOn, userProperties, additionalProperties)
        {
            VariableName = variableName;
            Value = value;
            Type = type ?? "AppendVariable";
        }

        /// <summary> Name of the variable whose value needs to be appended to. </summary>
        public string VariableName { get; set; }
        /// <summary> Value to be appended. Could be a static value or Expression. </summary>
        public object Value { get; set; }
    }
}

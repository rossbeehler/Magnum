// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.RulesEngine.SemanticModel
{
	using System;
	using System.Linq.Expressions;

	public abstract class Declaration
	{
		protected Declaration(DeclarationType partType)
		{
			NodeType = partType;
		}

		public DeclarationType NodeType { get; protected set; }



		public static ConditionDeclaration Condition<T>(Expression<Func<T, bool>> expression)
			where T : class
		{
			var declaration = new ConditionDeclaration(typeof (T), expression);

			return declaration;
		}

		public static ConsequenceDeclaration Consequence(Expression<Action> expression)
		{
			var declaration = new ConsequenceDeclaration(expression);

			return declaration;
		}

		public static ConsequenceDeclaration<T> Consequence<T>(Expression<Action<RuleContext<T>>> expression)
		{
			var declaration = new ConsequenceDeclaration<T>(expression);

			return declaration;
		}

		public static RuleDeclaration Rule(ConditionDeclaration[] conditions, ConsequenceDeclaration[] consequences)
		{
			var declaration = new RuleDeclaration(conditions, consequences);

			return declaration;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Foilr
{
	public static class WriteExtensions
	{
		public static void Write<T>(this IDictionary<string, object> values, 
		                            Expression<Func<T, object>> expression, T record, object value = null)
		{
			var property = getProperty(expression);
			var attribute = property
				.GetCustomAttributes(typeof(AliasAttribute), false)
				.OfType<AliasAttribute>()
				.FirstOrDefault();
			var key = attribute != null ? attribute.Alias : property.Name.ToLower();
			if(value == null)
			{
				value = property.GetValue(record, null);
			}

			if (value != null && !string.IsNullOrEmpty(value.ToString()))
			{
				values.Add(key, value);
			}
		}

		private static PropertyInfo getProperty<TModel>(Expression<Func<TModel, object>> expression)
		{
			MemberExpression memberExpression = getMemberExpression(expression);
			return (PropertyInfo)memberExpression.Member;
		}

		private static MemberExpression getMemberExpression<TModel, T>(Expression<Func<TModel, T>> expression)
		{
			MemberExpression memberExpression = null;
			if (expression.Body.NodeType == ExpressionType.Convert)
			{
				var body = (UnaryExpression)expression.Body;
				memberExpression = body.Operand as MemberExpression;
			}
			else if (expression.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpression = expression.Body as MemberExpression;
			}


			if (memberExpression == null) throw new ArgumentException("Not a member access", "member");
			return memberExpression;
		}
	}
}
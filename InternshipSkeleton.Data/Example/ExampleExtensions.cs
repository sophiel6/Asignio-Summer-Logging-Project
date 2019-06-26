using Utilities;

namespace AsignioInternship.Data.Example
{
	internal static class CountryDataModelExtensions
	{
		internal static ExampleDataModel ToModel(this ExamplePoco source)
		{
			if (null != source)
			{
			
				return new ExampleDataModel
				{
					BoolValue = source.BoolValue,
					DateAdded = source.DateAdded,
					DoubleValue = source.DoubleValue,
					ExampleID = GuidMapper.Map(source.ExampleID),
					IntValue = source.IntValue,
					Name = source.Name,
					StringValue = source.StringValue,
				};
			}

			return null;
		}

		internal static ExamplePoco ToPoco(this ExampleDataModel source)
		{
			if (null != source)
			{

				return new ExamplePoco
				{
					BoolValue = source.BoolValue,
					DateAdded = source.DateAdded,
					DoubleValue = source.DoubleValue,
					ExampleID = GuidMapper.Map(source.ExampleID),
					IntValue = source.IntValue,
					Name = source.Name,
					StringValue = source.StringValue,
				};
			}

			return null;
		}
	}
}

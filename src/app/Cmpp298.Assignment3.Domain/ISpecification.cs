namespace Cmpp298.Assignment3.Domain {
	internal interface ISpecification< T > {
		bool IsSatisfiedBy( T item );
	}
}
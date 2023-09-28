namespace TpIntegradorSofttekFront.Models
{
	public class SuccessResponse<T>
	{
		public int Status { get; set; }
		public T? Data { get; set; }
       
    }

    public class SuccessResponseList<T> 
    {
        public int Status { get; set; }
        public List<T>? Data { get; set; }

    }
}

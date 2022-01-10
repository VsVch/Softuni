using SUS.HTTP;

namespace SUS.mvcFramework
{
    public class HttPostAttribute : BaseHttpAttribute
    {
        public HttPostAttribute()
        {

        }

        public HttPostAttribute(string url)
        {
            this.Url = url;
        }
        public override HttpMethod Method => HttpMethod.Post;
    }


}

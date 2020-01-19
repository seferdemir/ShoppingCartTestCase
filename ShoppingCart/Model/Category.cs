namespace ShoppingCart.Model
{
    public class Category
    {
        private string Title { get; set; }
        private Category ParentCategory { get; set; }

        public Category(string title)
        {
            this.Title = title;
        }

        public Category(string title, Category parentCategory)
        {
            this.Title = title;
            this.ParentCategory = parentCategory;
        }

        public string getTitle()
        {
            return Title;
        }

        public void setTitle(string title)
        {
            Title = title;
        }

        public Category getParentCategory()
        {
            return ParentCategory;
        }

        public void setParentCategory(Category parentCategory)
        {
            ParentCategory = parentCategory;
        }
    }
}

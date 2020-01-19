namespace ShoppingCart.Model
{
    public class Category
    {
        private string Title { get; set; }
        private Category ParentCategory { get; set; }

        public Category(string Title)
        {
            this.Title = Title;
        }

        public Category(string Title, Category ParentCategory)
        {
            this.Title = Title;
            this.ParentCategory = ParentCategory;
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

        public void setParentCategory(Category category)
        {
            ParentCategory = category;
        }
    }
}

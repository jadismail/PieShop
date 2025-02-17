using Microsoft.AspNetCore.Razor.TagHelpers;
namespace PieShop.TagHelpers;

public class EmailTagHelper : TagHelper
{
    public string? Address { get; set; }
    public string? Content { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Content.SetContent(Content);
        output.Attributes.SetAttribute("href" , "mailto:" + Address );
    }
}
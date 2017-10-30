$(document).ready(function () {
    $('#ExpenseCategory').on('change', function () {
        var categoryId = $(this).val();

        if (categoryId !== "default") {
            $.ajax({
                type: 'GET',
                url: '/ApprovedPretravelClaim/GetSubCategories/' + categoryId,
                success: function (subcategories) {
                    options = '<option value="default">select a sub category</option>';
                    $.each(subcategories, function (index, subcategory) {
                        options += '<option value="' + subcategory.subCategoryId + '">' + subcategory.subCategoryName + '</option>';
                    });
                    $('#ExpenseSubCategory').html(options);
                }
            });
        }
        else
        {
            options = '<option value="default">select a sub category</option>';
            $('#ExpenseSubCategory').html(options);
        }
    });
});
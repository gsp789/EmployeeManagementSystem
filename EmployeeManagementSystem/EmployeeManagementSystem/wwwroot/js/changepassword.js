$(document).ready(function () {
    $('#changepassword').on('click', function () {
        var guid = $('#Guid').val();
        var newpassword = $('#NewPassword').val();
        var data = {
            'Guid': guid,
            'NewPassword': newpassword
        };
        var dataType = 'application/json';
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: 'POST',
            url: '/ForgotPassword/RecoverPassword/',
            data: JSON.stringify(data),
            dataType: 'json',
            success: function (response) {
                $('#successModal').modal('show');
            },
            error: function (response) {
                $('#errorModal').modal('show');
            }
        });
    });
});
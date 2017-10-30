$(document).ready(function () {

    $("#approve").click(function () {
        var claimId = $("#claimId").val();
        var status = "Approve";
        doPostcall(claimId, status);
    });

    $("#decline").click(function () {
        var claimId = $("#claimId").val();
        var status = "Decline";
        doPostcall(claimId, status);
    });
    $("#warning").click(function () {
        var claimId = $("#claimId").val();
        var status = "Pending";
        doPostcall(claimId, status);
    });



    var doPostcall = function (claimId, status) {
        var data = {
            claimId: claimId,
            Status: status
        }



        var updateStatus = $.ajax({
            type: "POST",
            url: "/TravelClaimApprover/Index",
            data: data,
            success: function (data) {

            },
           
        });
        updateStatus.fail(function () {

        })
    }

});
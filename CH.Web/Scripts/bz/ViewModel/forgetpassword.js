
var CH = CH || {};

CH.viewModel = CH.viewModel || {};
CH.viewModel.forgetpassword = (function (ut) {

    ut.userName = ko.observable();

    ut.userEmail = ko.observable();

    ut.verifyCode = ko.observable();

    ut.refreshCode = function (data, event) {

        $(event.target).attr("src", "/Account/VerifCode?" + Math.random(1, 1000));

    };


    ut.submit = function () {

        var isValid = $("#ff").form('validate');
        if (isValid)
        {
            $.ajax({

                type: 'post',
                url: '/account/ForgetPwd/',
                dataType: 'json',
                data: { userName: ut.userName(), userEmail: ut.userEmail(), verifyCode: ut.verifyCode() },
                //contentType: 'application/json',
                success: function (d) {
                    if (d.status == 'N') {

                        $(".error").html(d.msg);
                    }
                    else {

                        location.href = "/account/EmailSuccess";
                    }
                }
            });
        }
       

    };
    ut.clear = function () {

        alert('msg');
    };
    return ut;
})(CH.viewModel.forgetpassword || {});
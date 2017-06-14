
var CH = CH || {};

CH.viewModel = CH.viewModel || {};
CH.viewModel.userPwdReset = (function (token) {

    var that = this;

    this.userPwd1 = ko.observable();

    this.userPwd2 = ko.observable(); 
    this.submit = function () {

        var isValid = $("#ff").form('validate');
        if (isValid)
        {
            $.ajax({

                type: 'post',
                url: '/api/Sys/SysUserapi/EditPwdReset/'+token,
                dataType: 'json',
                data: { userPwd1: that.userPwd1(), userPwd2: that.userPwd2() },
                //contentType: 'application/json',
                success: function (d) {
                    if (d.status == 'N') {

                        $(".error").html(d.msg);
                    }
                    else {
                        $(".error").html('密码修改成功,将跳向主页');
                        location.href = "/account/index";
                    }
                }
            });
        }
       

    };
    this.clear = function () {

        alert('msg');
    }; 
});
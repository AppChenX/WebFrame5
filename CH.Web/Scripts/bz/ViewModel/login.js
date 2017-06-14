
var CH = CH || {};

CH.viewModel = CH.viewModel || {};
//登录
CH.viewModel.logInOut = (function (ut) {
    ut.userName = ko.observable();
    ut.userPwd = ko.observable();
    ut.imgCode = ko.observable();

    ut.keyfun = function (data,event) {
         
        if(event.keyCode==13)
        {
            $(event.target).blur();
            ut.login();
            return false;
        }
        else
        {
            return true;
        }
       
    };
    /*
	 *登录验证
	 */
    ut.login = function () {
        var url = '/sys/SysUser/ValidUser';
        var homeUrl = '/Home/Index';
        $.ajax({
            type: 'get',
            url: url,
            dataType: 'json',
            data: {
                username: ut.userName(),
                userpwd: $.md5(ut.userPwd()),
                code: ut.imgCode()
            },
            beforeSend: function (XMLHttpRequest) {
                $('.message').text('正在登录..');
            },
            success: function (d) {

                if (d != null) {
                    if (d.status == 'N') {
                        $('.message').text(d.msg);
                    } else {
                        $('.message').text('登录成功在正跳转');
                        setTimeout(function () {
                            window.location.href = homeUrl;
                        }, 1000);
                    }
                } else {
                    $('.message').text('系统验证方法出错');
                }
            } 

        });
    };

    /*
	 * 重置用户名密码
	 */
    ut.reset = function () {

        ut.userName('');
        ut.userPwd('');
    };

    /*
     刷新验证码
    */
    ut.refreshCode = function (data, event) {

        $(event.target).attr("src", "/Account/VerifCode?" + Math.random(1, 1000));

    };

   
  
    return ut;

})(CH.viewModel.login || {});

/*
var CH = CH || {};
CH.Account = CH.Account || {};
CH.Account.login = function () {

var url = '/sys/SysUser/ValidUser';
var homeUrl = '/Home/Index';
$.ajax({
type: 'get',
url: url,
dataType: 'json',
data: {
username: $('#txtUserName').val(),
userpwd: $('#txtUserPwd').val(),
code: $('#txtCode').val()
},
beforeSend: function (XMLHttpRequest) {
$('.message').text('正在登录..');
},
success: function (d) {


if (d != null) {
if (d.status == 'N') {
$('.message').text(d.msg);
}
else {
$('.message').text('登录成功在正跳转');
setTimeout(function () {
window.location.href = homeUrl;
}, 3000);
}
}
else {
$('.message').text('系统验证方法出错');
}
},

error: function (x, e, o) {
$('.message').text(e);
}


});




};

CH.Account.refreshCode = function (ele){

$(ele) .attr("src", "/Account/VerifCode?" + Math.random(1,1000));

}

$(function () {

$(".login_button").click(function () {

CH.Account.login();
});
});

*/
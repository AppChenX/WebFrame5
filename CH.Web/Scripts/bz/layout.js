var CH = CH || {};

CH.Layout = (function (ut) {

    
   
    /*
     初始化首页界面
    */
    ut.init = function (useriId) {

         
        //body 展开时可resize
        $('body').layout({
            onExpand: function () {
                $('body').layout('resize');
            }
        });

        //加载Tab
        $('#tabs').tabs({
            tools: [{
                iconCls: 'icon-reload',

                handler: function () {
                    var tab = $('#tabs').tabs('getSelected');
                    if (tab.panel('options').id != CH.seetings.OnlyOpenId)
                        CH.utils.rightTabMenu($("#tabs"), 'refresh');
                    return false;
                }
            },
            {
                iconCls: 'panel-tool-close',
                handler: function () {
                    if (confirm('确认要关闭所有窗口吗？')) {
                        CH.utils.rightTabMenu($("#tabs"), "closeall");
                    }
                }
            },
            {
                iconCls: 'icon-screen_full',
                handler: function () {
                    CH.utils.screenFull($(this));
                }
            }]
            ,
            onContextMenu: function (e, title) {
                e.preventDefault();
                $('#closeMenu').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                }); 
                
            }
        });
        //
        $('#closeMenu').menu({
            onClick: function (item) {

                CH.utils.rightTabMenu($("#tabs"), item.id, $('#closeMenu'));
            }
        });

        //加载权限菜单
        $.ajax({
            type: 'POST',
            url: '/api/sys/SysMenuApi/PostMenuByUserId',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify({ uid: useriId }),
            beforeSend: function (r) {
                $("#tree_loading").html("<img src='/Content/Images/loading.gif' /><span>数据加载中..</span>");
            },
            success: function (d) {

                
                if (!d)
                {
                    $("#tree_loading").html('<span>请求数据异常</span>');
                }
                else
                {

                    ut.treeInit(d);
                } 

                //if (!d) {
                //    $.messager.alert("系统提示", "<font color=red><b>您没有任何权限！请联系管理员。</b></font>", "warning", function () {
                //        location.href = '/Account/Login';
                //    });
                //}
                
            },
            complete: function (XMLHttpRequest, textStatus) {

                if (textStatus == 'error') {
                    $("#tree_loading").html('<span>' + XMLHttpRequest.statusText + '</span>');
                }
                else {
                    $("#tree_loading").empty();
                } 
            }
        });
    };

    /*
     加载菜单树
    */
    ut.treeInit = function (zNodes) {


        var setting = {
            view: {
                dblClickExpand: false,
                showLine: true,
                selectedMulti: false
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pId",
                    rootPId: "",
                    iconCls: 'iconCls'
                }
            },
            callback: {

                onClick: function (event, treeId, treeNode) {

                    var zTree = $.fn.zTree.getZTreeObj("tree");
                    if (treeNode.isParent) {
                        zTree.expandNode(treeNode);

                    } else {

                        CH.utils.addTab($("#tabs"),treeNode.name, treeNode.id, treeNode.file, treeNode.iconCls);

                    }


                }
            }
        };

        var t = $('#tree');
        t = $.fn.zTree.init(t, setting, zNodes);

    };


    ut.changePassword = function () {
        CH.utils.dialog({
            title: "&nbsp;修改密码",
            iconCls: 'icon-key',
            width: 320,
            height: 204,
            html: "#password-template",
            //submmit: function () {
            //    if ($('#password_form').form('validate')) {
            //        alert('msg');
            //    }
            //    else
            //        alert('not validate');

               
            //},
            submit: function ()
            {
                //alert(w.dialog('options').title);
                alert(that.password());
            },
            viewModel: function ( w) {
                  
                var that = this;
                this.password = ko.observable();
                this.userpwd1 = ko.observable();
                this.userpwd2 = ko.observable();
               

                return that;
            }
        });
    };
    

    /* 
    退出登录
    */
    ut.signOut = function () {
        $.messager.confirm('系统提示', '是否退出本次登录？', function (r) {
            if (r) {
                location.href = '/Account/Logout';
            }
        });
    };
    
    //修改密码
    $('.changepwd').click(ut.changePassword);
    $('.loginOut').click(ut.signOut);
    




    return ut;
})(CH.Layout || {});



 
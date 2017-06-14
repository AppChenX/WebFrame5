var viewModle_bz = viewModle_bz || {};

/*

 用户角色管理
*/
viewModle_bz.sys_roleuser = function (row,userId) {


    var that = this;  
    this.roleName = row.RoleName; 
    this.roleDesc = '['+row.RoleDesc+']';

    this.users = ko.observableArray([]);


    ///删除用户
    this.remove = function () {

       // alert(this);
        that.users.remove(this);
    };

    

    //新增用户弹出可选择的用户窗体
    this.addUser = function (m) {

       var dialog= CH.utils.dialog({
            title: "&nbsp;选择用户",
            iconCls: 'icon-users',
            width: 500,
            height: 400,
            html: "#menuroleedit-selectuser-template",
            buttons: [ 
       {
           text: '确定',
           iconCls: 'icon-save',
           handler: function () {

                //选择用户  //排除已经选择的用户
               var rows = dialog.model.grid.datagrid('getChecked');
                if (rows)
                {

                    var users = that.users();
                       for(var row in rows)
                       {  
                           var m = Enumerable.From(users).Where(function (i) { 
                               return i.UserId === rows[row].UserId;
                           }).FirstOrDefault();
                           if(!m)
                           that.users.push({ 'UserId': rows[row].UserId , 'UserName':rows[row].UserName }); 
                       } 
                }
                dialog.dialog('close');

           }
       }, {
           text: '关闭',
           iconCls: 'icon-cancel',
           handler: function () {

               dialog.dialog('close');
           }

       }
            ],
            viewModel: function (w) {


                var viewModel = this; 

                viewModel.grid = {
                    title: "用户",
                    rownumbers: true,
                    selectOnCheck: true, 
                    checkOnSelect: true, 
                    singleSelect: false,
                    idField: 'UserId',
                    border: false,
                    striped: true,
                    sortName: 'userId',
                    collapsible: false,
                    method: 'get',
                    url: '/Api/Sys/SysUserApi/GetUser/'+userId,
                    queryParams: { 'userId': '', 'userName': '' }, 
                   pageSize: 10,
                   pageNumber: 1,
                    columns: [[
                        {
                            field : 'ck',
                            checkbox : true
                        },{
                        field: 'UserId',
                        title: '用户ID',
                        algin: 'center',
                        sortable: true,
                        editor: {
                            type: 'validatebox',
                            options: {
                                required: 'true',
                                validType: ["length[1,20]"]
                            }
                        }
                    }, {
                        field: 'UserName',
                        title: '用户名',
                        align: 'center',
                        editor: {
                            type: 'validatebox',
                            options: {
                                required: 'true',
                                validType: ["length[1,20]"]
                            }
                        }
                    }, {
                        field: 'UserEmail',
                        title: '邮箱',
                        align: 'center',
                        editor: {
                            type: 'validatebox',
                            options: {
                                required: 'true',
                                validType: ["email", "length[1,20]"]
                            }
                        }
                    }, {
                        field: 'UserMobile',
                        title: '手机',
                        align: 'center',
                        editor: {
                            type: 'numberbox',
                            options: {
                                required: 'false'
                            }
                        }
                    },   {
                        field: 'IsAdmin',
                        title: '超级管理员',
                        align: 'center',
                        formatter: CH.utils.setChecbox,
                        editor: {
                            type: 'checkbox',
                            options: {
                                on: true,
                                off: false
                            }
                        }
                    }, {
                        field: 'UserSex',
                        title: '性别',
                        align: 'center',
                        formatter: CH.utils.sextdataFormatter,
                        editor: {
                            type: 'combobox',
                            options: {
                                panelMaxHeight: 50,
                                data: CH.utils.sexdata,
                                valueField: 'value',
                                textField: 'text',
                                editable: false
                            }
                        }
                    }, {
                        field: 'UserAddress',
                        title: '地址',
                        align: 'center',
                        editor: {
                            type: 'textbox',
                            options: {
                                multiline: true
                            }
                        }
                    }

                    ]]
                };
                 
                return viewModel;
              
            }
        });
    };
    ///保存用户角色
    this.saveUser = function (dialog) {
       
       
        parent.$.messager.confirm('提示','是否保存此角色'+that.roleName+'下的用户?', function (r) {

            if (r) { save(); };
        });
        //调用api执行对应的按钮权限
        var save = function () {

            $.ajax({
                type: 'post',
                url: '/api/sys/SysRoleApi/EditUserRole/' + row.RoleId,
                dataType: 'json',
                data: JSON.stringify(that.users()),
                contentType: 'application/json',
                success: function (d) {

                    if (d) {
                        if (!d.status) {

                            parent.$.messager.alert("错误", d.msg, 'error');
                        }
                        else {
                            dialog.dialog('close');
                        }
                    }
                }
            });
        };
        

    };
    //获取角色下的用户

    var init = function () {

        $.ajax({ 
            type: 'get',
            url: '/api/sys/SysUserApi/GetRoleUser', //获取角色下的用户
            dataType: 'json',
            data: { roleid: row.RoleId },
            contentType: 'application/json',
            success: function (d) {

                that.users(d); 

            
            }
        });
    }; 
   
    init();

   
}
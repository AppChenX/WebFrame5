var viewModle_bz = viewModle_bz || {};

viewModle_bz.sys_role_member = function (row, userId) {

    var that = this;
    //当前角色所拥有的角色
    this.roles = ko.observableArray([]);

    this.roleName = row.RoleName;

    this.roleDesc = row.RoleDesc;


    /*
    保存角色所属角色
    */
    this.submit = function (dialog) {


        if (that.roles())
        {
            if(that.roles().length>0)
            {
                 
                var _json = [];
                _json.push({ RoleId: row.RoleId, RolePid: that.roles()[0].RolePid });

                $.ajax({

                    type: 'post',
                    url: '/api/sys/SysRoleApi/EditRoleMember/' + userId,
                    dataType: 'json',
                    data: JSON.stringify(_json),
                    contentType: 'application/json',
                    success: function (d) {
                        if (!d.status) {

                            parent.$.messager.alert("错误", d.msg, 'error');
                        }
                        else {
                            dialog.dialog('close');
                        }
                    }
                });
            }
        }
        ///保存角色所属角色 构造对应的json数据

        
    };

    /*
    *选择角色 
    *@param m model
    */
    this.selectRole = function (m) {

        var dialog = CH.utils.dialog({
            title: "&nbsp;选择角色",
            iconCls: 'icon-users',
            width: 500,
            height: 400,
            html: "#roleedit-selectrole-template",
            buttons: [
       {
           text: '确定',
           iconCls: 'icon-save',
           handler: function () {

               //选择用户  //排除已经选择的用户
               var rows = dialog.model.grid.datagrid('getChecked');
               if (rows) {

                   if (!rows[0].RoleId)
                   {
                       parent.$.messager.alert('错误','用户角色数据维护有问题','warning');
                   } else {

                       //构造相同的json串
                       var _json = []; 
                       _json.push({RoleId:row.RoleId,RolePid:rows[0].RoleId,RoleName:rows[0].RoleName,RoleDesc:rows[0].RoleDesc});

                       that.roles(_json);
                       dialog.dialog('close');
                   }
               }

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
                    title: "角色",
                    rownumbers: true,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    singleSelect: true, 
                    idField: 'RoleId',
                    border: false,
                    striped: true,
                    sortName: 'RoleId',
                    collapsible: false,
                    method: 'get',
                    url: '/Api/Sys/SysRoleApi/GetRoleByUserId/' + userId, //获取登录用户下的角色的所有角色
                    queryParams: ko.observable(),
                    pagination:false,
                    pageSize: 10,
                    pageNumber: 1,  
                    loadFilter:function(data)
                    {


                        ///组合数据，加上管理员
                        if(data)
                        {
                             
                             data.unshift({ RoleId: '0', RoleName: '超级管理员', RoleDesc: '超级管理员' });

                             return { total: data.length, rows: data };
                        }

                    },
                    columns: [[
                        {
                            field: 'ck',
                            checkbox: true
                        }, {
                            field: 'RoleId',
                            title: '角色ID',
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
                            field: 'RoleName',
                            title: '角色名称',
                            align: 'center',
                            editor: {
                                type: 'validatebox',
                                options: {
                                    required: 'true',
                                    validType: ["length[1,20]"]
                                }
                            }
                        },
        {
            field: 'RoleDesc',
            title: '角色描述',
            align: 'center',
            editor: {
                type: 'validatebox',
                options: {
                    required: 'false',
                    validType: ["length[0,200]"]
                }
            }
        }

                    ]]
                };

                return viewModel;

            }
        });
    };


    /*

     *初始化 查找对应的角色所属角色
    */
    var init = function () {
        $.ajax({

            type: 'post',
            url: '/api/sys/SysRoleApi/PostRoleMember/',
            dataType: 'json',
            data: JSON.stringify({roleId:row.RoleId}),
            contentType: 'application/json',
            success: function (d) {
                if (d) {
                    that.roles(d);
                }
                   
            }
        });
        //
    };
    //init 结束

    init();


};
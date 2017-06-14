
var viewModle_bz = viewModle_bz || {};

viewModle_bz.sys_user = function (userId) {

    var that = this;

    this.formatterButton = function (value, row,index) {
        return '<a href="#" onclick="sys_user_setUserRole(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-set2">&nbsp;</span>[用户角色]</a><a href="#" onclick="sys_user_setUserDepartment(\'' + index + '\',\'' + userId + '\')"><span class="icon icon-group_gear">&nbsp;</span>[用户部门]</a> ';
    };

    this.queryParams = {
        userId: ko.observable(),
        userName: ko.observable()
    };

    this.grid = {
        title: "用户管理",
        rownumbers: true,
        idField: 'userId',
        border: false,
        //striped: true,
        singleSelect: true,
        pageSize: 10 ,
        sortName: 'userId',
        collapsible: false,
        method: 'get',
        url: '/Api/Sys/SysUserApi/GetUser/'+userId,
        queryParams:  ko.observable(),
        columns: [[
				{
				    title: '操作',
				    field: 'button',
				    formatter: that.formatterButton
				    //width: 150
				},
				{
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
				}, {
				    field: 'IsEnable',
				    title: '禁用',
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
				    field: 'IsAdmin',
				    title: '超级管理员',
				    align: 'center',
				    formatter: CH.utils.setChecbox 
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

    this.gridEdit = new CH.utils.editGridViewModel(that.grid);
    this.grid.onDblClickRow = that.gridEdit.begin;
    this.grid.onClickRow = that.gridEdit.ended;

    this.search = function () {

        that.grid.queryParams(ko.toJS(that.queryParams));
    };
    this.undo = function () {
        this.gridEdit.reject();
    };
    this.add = function () {
        this.gridEdit.addnew({
            'MenuSeq': 0,
            'IsEnable': true
        });
    }
    this.save = function () {
        this.gridEdit.save({
            url: '/api/sys/SysUserApi/EditUser/'+userId
        });
    };
    this.edit = function () {

        var row = that.grid.datagrid('getSelected');
        if (!row)
            return $.messager.alert("提示", '请选择要编辑的数据', 'warning');
        that.gridEdit.begin();

    };
    this.del = function () {
        var row = that.grid.datagrid('getSelected');
        if (!row)
            return $.messager.alert("提示", '请选择要删除的数据', 'warning');
        if (row.IsAdmin) {

            $.messager.alert("提示", '超级管理员无法删除', 'warning');
            return;
        }
        that.gridEdit.deleterow();
    };
    this.queryParams.userId("");
    this.queryParams.userName("");
};
//ko.applyBindings(new viewModle_bz.sys_user());

/*
 * 弹出用户角色管理
@param {row} 获取当前数据行
 */
var sys_user_setUserRole = function (index, userId) {

    var row = m_sys_user.grid.datagrid('getRows')[index];
    if (row.IsAdmin)
    {
        parent.$.messager.alert('提示','超级管理员不用设置角色','info');
        return;
    }

    var dialog = CH.utils.dialog({
        title: "&nbsp;用户角色管理",
        iconCls: 'icon-users',
        width: 500,
        height: 300,
        html: "#userroleedit-template",
        buttons: [{
            text: '选择',
            iconCls: 'icon-group-add',
            handler: function () {

                var viewModel = dialog.model;
                viewModel.selectRole();

            }
        }, {
            text: '保存',
            iconCls: 'icon-save',
            handler: function () {

                var viewModel = dialog.model;
                viewModel.submit();
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

            var that = this;
            this.userId = row.UserId;
            this.userName = row.UserName;
            this.roles = ko.observableArray();


            //console.log('userId:'+userId);
            //console.log('this.userId:' + that.userId);
            //console.log('this.userId:' + this.userId);
            
            this.newRoles = function (a1, a2) {
                var a = [];
                $.each(a1, function (index,item) {

                    a.push($.extend(item, a2));
                });

                return a;
            }
            /*
          *  保存相应行的用户角色 
          */
            this.submit = function () {
                 
                $.ajax({
                    type: 'post',
                    url: '/api/sys/SysRoleApi/EditUserRole1/',
                    dataType: 'json',
                    data:JSON.stringify(that.newRoles(that.roles(), {"UserId":row.UserId})),
                    contentType: 'application/json',
                    success: function (d) {
                        if (d) {

                            if (!d.status)
                                parent.$.messager.alert('错误', d.msg, 'error');
                            else
                                dialog.dialog('close');

                        }
                    }
                });

            };
            //初始化获取对应的用户的角色
            var init = function () {
                $.ajax({
                    type: 'post',
                    url: '/api/sys/SysRoleApi/PostRoleByUserId' ,
                    dataType: 'json',
                    data: JSON.stringify({
                        userId:row.UserId
                    }),
                    contentType: 'application/json',
                    success: function (d) {
                        if (d) {

                            that.roles(d);
                        }
                    }
                }); 

                //ajax请求
            };
            
            /*
            * 选择角色，弹出当前登录用户下的所有角色
            */
            this.selectRole = function () {

                //
                var dialog = CH.utils.dialog({
                    title: "&nbsp;角色选择",
                    iconCls: 'icon-users',
                    width: 500,
                    height: 400,
                    html: "#roleselect-template",
                    submit: function () {

                        var vm = dialog.model;
                        vm.select();
                    },
                    viewModel: function (w) {

                        //定义Model
                        var that_roleselect = this;

                        this.grid = {
                            title: "角色管理",
                            selectOnCheck: true,
                            checkOnSelect: true,
                            singleSelect: false,
                            rownumbers: true,
                            pagination: false,
                            singleSelect: true,
                            pageSize: 10,
                            pageNumber: 1,
                            idField: 'RoleId',
                            border: false,
                            striped: true,
                            sortName: 'RoleId',
                            collapsible: false,
                            method: 'get',
                            url: '/Api/Sys/SysRoleApi/GetSysRole',
                            queryParams: ko.observable(),
                            columns: [[{
                                field: 'ck',
                                checkbox: true
                            }, {
                                field: 'RoleId',
                                title: '角色ID',
                                algin: 'center',
                                sortable: true
                            }, {
                                field: 'RoleName',
                                title: '角色名称',
                                align: 'center'
                            }, {
                                field: 'RoleDesc',
                                title: '角色描述',
                                align: 'center'
                            }
                            ]]
                        };

                        /*
                         * 弹出用户角色管理
                         */
                        this.select = function () {

                            var checkedrows = that_roleselect.grid.datagrid('getChecked');

                            if (checkedrows) {
                                if (checkedrows.length > 1)
                                    parent.$.messager.alert('提示', '只能选择一个角色', 'warning');
                                //设置角色
                                that.roles(checkedrows);
                                //关闭弹出窗体
                                dialog.dialog('close');

                            }
                        }

                        return that_roleselect;
                        //定义Model

                    }
                });
                //
            }; 

            init();

            return that;
        }
    });
};

/*
 * 弹出用户部门管理
@param {row} 获取当前数据行
 */
 
var sys_user_setUserDepartment = function (index,userId) {
    var row = m_sys_user.grid.datagrid('getRows')[index];
    var dialog = CH.utils.dialog({
        title: "&nbsp;用户岗位部门管理",
        iconCls: 'icon-group_gear',
        width: 500,
        height: 400,
        html: "#userdepartmentedit-template",
        submit: function () {

            var viewModel = dialog.model;
            viewModel.submit(dialog);

        },
        viewModel: function (w) {

            var that = new viewModle_bz.sys_userdepartment(row,userId);

            return that;
        }
    });
};
var viewModle_bz = viewModle_bz || {};

/*

 用户角色管理
*/
viewModle_bz.sys_userdepartment = function (row,userId) {


    var that = this;

    this.submit = function (dialog) {
         
       
        var nodes = that.tree.zTree.getCheckedNodes();


        if(nodes)
        {
            if (nodes.length > 1) {
                parent.$.messager.alert('提示', '只能选择一个部门节点！', 'warning'); 
                return;
            }

               
            //调用api执行对应的按钮权限
            $.ajax({
                type: 'post',
                url: '/api/sys/SysDepartmentApi/EditUserDepartment/' + row.UserId,
                dataType: 'json',
                data: JSON.stringify(nodes),
                contentType: 'application/json',
                success: function (d) {
                    
                    if(d)
                    {
                        if (!d.status) {

                            parent.$.messager.alert("错误", d.msg, 'error');
                        }
                        else
                        {
                            dialog.dialog('close');
                        }
                    }
                }
            });
        } 
    }; 

    this.tree = {
        expandAll: true,
        url: '/api/sys/SysDepartmentApi/PostUserDepartment',
        method: 'post',
        data: JSON.stringify({ uid:row.UserId}),
        setting: {
            view: {
                selectedMulti: false
            },
            check: {
                enable: true,
                chkboxType: { "Y": "", "N": "" }
            },
            data: {

                key: {
                    checked: "Checked",
                    name: 'DepartmentName',
                },
                simpleData: {
                    enable: true,
                    idKey: "DepartmentId",
                    pIdKey: "DepartmentPid",
                    rootPId: "0",
                    iconCls: 'iconCls'

                }
            }
        }

    };
};


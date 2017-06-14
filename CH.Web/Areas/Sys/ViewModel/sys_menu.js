
/*
 此模块只能是超级管理员才能编辑数据
*/
var viewModle_bz = viewModle_bz || {};

viewModle_bz.sys_menu = function (userId) {

     
    var that = this;

    this.queryParams = { menuName: ko.observable() };
    

    var loadFilter = function (data) {

        data = CH.utils.copyProperty(data, ['id'], ['_id'], false); //复制一个_id的属性
        var data_new = CH.utils.toTreeData(data, '_id', 'pid', 'children'); //生成tree的json 格式，注意必须是_id, 因为id可能会编辑
        return data_new;

    }; 
    
    this.formatterButton = function (value, row) { return (row.file && row.file != '#') ? '<a href="#" onclick="setButton(\'' + row.id + '\',\'' +userId + '\')"><span class="icon icon-set2">&nbsp;</span>[设置按钮]</a>' : ''; };



    this.grid = {
        url: '/api/sys/SysMenuApi/GetMenuData',
        title: "菜单管理",
        idField: '_id',
        treeField: 'text',
        fit: true,
        fitColumns:true,
        //pagination:false,
        queryParams: ko.observable(),
        loadFilter: function (data) {

            return loadFilter(data);
        },
        columns: [[{
            title: '菜单ID',
            field: 'id',
            editor: { type: 'validatebox', options: { required: true, validType: ["length[1,20]"] } }
        }, {
            title: '菜单名',
            field: 'text',
            editor: { type: 'validatebox', options: { required: true, validType: ["length[1,20]"] } }
        }, {
            title: '父菜单',
            field: 'pid',
            editor: { type: 'combotree', options: { required: false, validType: ["length[1,20]"] } }
        }, {
            title: '菜单URL',
            field: 'file',
            editor: { type: 'validatebox', options: { required: false, validType: ["length[1,50]"] } }
        }, {
            title: '树图标地址',
            field: 'iconUrl',
            editor: { type: 'validatebox', options: { required: false, validType: ["length[1,50]"] } }
        }, {
            title: '图标',
            field: 'iconCls',
            width:140,
            editor: { type: 'lookup', options: { required: false, buttonIcon: 'icon-search',buttonText:'搜索' } }
        }, {
            title: '菜单序号',
            field: 'seq',
            editor: { type: 'numberbox', options: { required: false, precision: 0, validType: ["length[1,20]"] } }
        }, {
            title: '禁用',
            field: 'isEnable',
            formatter: CH.utils.setChecbox,
            editor: {
                type: 'checkbox',
                options: {
                    on: true,
                    off: false
                }
            }
        },
        {
            title: '页面按钮',
            field: 'button',
            formatter: that.formatterButton,
            width:100
        }
        ]]

    };
    
    this.gridEdit = new CH.utils.editTreeGridViewModel(that.grid, {
        combotree: {
            col: 'pid'
        },
        lookup: {
            col: 'iconCls'
        }
    });
    this.grid.onDblClickRow = this.gridEdit.begin;
    this.grid.onClickRow = that.gridEdit.ended;

    this.search = function () {

        that.grid.queryParams(ko.toJS(that.queryParams));
    };
    this.undo = function () {
        this.gridEdit.reject();
    };
    this.add = function () { 
        this.gridEdit.addnew();
    }
    this.save = function () {
        this.gridEdit.save({ url: '/api/sys/SysMenuApi/EditMenu' });
    };
    this.edit = function () {

        that.gridEdit.ended();

    };
    this.del = function () {
        that.gridEdit.deleterow();
    };


};



//
var setButton = function (menuid,userId) {


    CH.utils.dialog({
        title: "&nbsp;菜单按钮管理",
        iconCls: 'icon-key',
        width: 700,
        height: 500,
        html: "#actionedit-template",

        viewModel: function (w) {
            var that = new viewModle_bz.sys_action(menuid,userId);
            return that;
        }
    });

};
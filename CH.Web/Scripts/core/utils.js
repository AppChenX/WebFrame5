/*!
 *
Utils Javascript Library
 *
Chenl - v1.0.0 (2017-04-15T14:55:51+0800)
 *

 */

var CH = CH || {};

CH.utils = (function (ut) {

    ut.jqElement = function (element) {
        var jq = $(element);
        if ($(document).find(element).length == 0) {  //处理元素在父页面执行的情况
            if ($(parent.document).find(element).length > 0)
                jq = parent.$(element);
        }
        return jq;
    };
    //var CH.seetings.opentabs = 10;
    //var CH.seetings.OnlyOpenId = 'M0';
    //增加一个新Tabs;
    ut.addTab=function(elementTab, title,id,url,icon)
    {
        if (url == "" || url == "#")
            return false;
        var tabCount = elementTab.tabs('tabs').length;
        var hasTab = elementTab.tabs('exists', id);;
        var add = function () {
            if (!hasTab) { 

                elementTab.tabs('addIframeTab', {
                    tab: {
                     
                        title:title,
                        closable: true,
                        icon: icon,
                        id: id
                    },
                    iframe: { src: url }
                }); 
            } else {
                elementTab.tabs('select', id);
                //closeTab('refresh'); //选择TAB时刷新页面
            }
        };
        if (tabCount > CH.seetings.opentabs && !hasTab) {
            var msg = '<b>您当前打开了太多的页面，如果继续打开，会造成程序运行缓慢，无法流畅操作！</b>';
            $.messager.confirm("系统提示", msg, function (b) {
                if (b) add();
                else return false;
            });
        } else {
            add();
        }
    };

    /*
    关闭标签
    */
    ut.closeTab = function (elementTab) {
        $(".tabs-inner").live('dblclick', function () {
            var id = $(this).children(".tabs-closable").id;
            if (id != CH.seetings.OnlyOpenId && id != "")
                elementTab.tabs('close', id);
        });
    };


    /*
     tabs右键
    */
    ut.rightTabMenu = function (elementTab, action,elementMenu )
    {
       var alltabs = elementTab.tabs('tabs');
       var currentTab = elementTab.tabs('getSelected');
        var allTabtitle = [];
        $.each(alltabs, function (i, n) {
            allTabtitle.push($(n).panel('options').id);
        });
        switch (action) {
            case "refresh":
                var tab = elementTab.tabs('getSelected');
                var id = tab.panel('options').id;
                elementTab.tabs('updateIframeTab', { 'which': id });
                break;
            case "close":
                var id = currentTab.panel('options').id;

                if (id!=null&& id!= CH.seetings.OnlyOpenId)
                {
                    elementTab.tabs('close', id);
                }
              
                break;
            case "closeall":
                $.each(allTabtitle, function (i, n) {
                    if (n != CH.seetings.OnlyOpenId) {
                        elementTab.tabs('close', n);
                    }
                });
                break;
            case "closeother":
                var id = currentTab.panel('options').id;
                $.each(allTabtitle, function (i, n) {
                    if (n != id && n != CH.seetings.OnlyOpenId) {
                        elementTab.tabs('close', n);
                    }
                });
                break;
            case "closeright":
                var tabIndex = elementTab.tabs('getTabIndex', currentTab);

                if (tabIndex == alltabs.length - 1) {
                    alert('亲，后边没有啦 ^@^!!');
                    return false;
                }
                $.each(allTabtitle, function (i, n) {
                    if (i > tabIndex) {
                        if (n != CH.seetings.OnlyOpenId) {
                            elementTab.tabs('close', n);
                        }
                    }
                });

                break;
            case "closeleft":
                var tabIndex = elementTab.tabs('getTabIndex', currentTab);
                if (tabIndex == 1) {
                    alert('亲，前边那个上头有人，咱惹不起哦。 ^@^!!');
                    return false;
                }
                $.each(allTabtitle, function (i, n) {
                    if (i < tabIndex) {
                        if (n != CH.seetings.OnlyOpenId) {
                            elementTab.tabs('close', n);
                        }
                    }
                });

                break;
            case "exit":
                elementMenu.menu('hide');
                break;
        }
    };

    /*
     全屏
    */
    ut.screenFull=function(that)
    {
        //var that = $(this);
        if (that.find('.icon-screen_full').length) {
            that.find('.icon-screen_full').removeClass('icon-screen_full').addClass('icon-screen_actual');
            $('[region=north],[region=west]').panel('close')
            var panels = $('body').data().layout.panels;
            panels.north.length = 0;
            panels.west.length = 0;
            if (panels.expandWest) {
                panels.expandWest.length = 0;
                $(panels.expandWest[0]).panel('close');
            }
            $('body').layout('resize');
        } else if (that.find('.icon-screen_actual').length) {
            that.find('.icon-screen_actual').removeClass('icon-screen_actual').addClass('icon-screen_full');
            $('[region=north],[region=west]').panel('open');
            var panels = $('body').data().layout.panels;
            panels.north.length = 1;
            panels.west.length = 1;
            if ($(panels.west[0]).panel('options').collapsed) {
                panels.expandWest.length = 1;
                $(panels.expandWest[0]).panel('open');
            }
            $('body').layout('resize');
        }
    };

 /*
 * 扩展 dialog 
 @param {options}  easyui dialog options 选项[url,html,viewModel]
 */
    ut.dialog = function (options) {

         
         
        var jquery =parent.$;
        //var fnClose = options.onClose;
        var tagetHtml = '';//html 内容
        var dialogId; //对话框ID
        var defaultButtons = [];

        var viewModel = null;

        options = jquery.extend({
            title: 'My Dialog',
            width: 400,
            height: 220,
            closed: false,
            cache: false,
            modal: true,
            html: '',
            url: '',
            showButtons: true,
            onClose: function () { },
            vp:{}, //ViewModle参数
            viewModel: jquery.noop   //设置为空函数
        }, options);


        var fnClose = options.onClose;

        if (options.id) {
            dialogId = options.id;
        }
        else
            dialogId = ut.uuid(8, 16);
        if (!options.showButtons)
        {
            defaultButtons = [];
        }
        
       
      
        //销毁dialog
        options.onClose = function () {
            if (fnClose) fnClose();
            jquery(this).dialog('destroy');
        };


        if (jquery.isFunction(options.html))
        {
            var html = options.html.call(); //调用函数 返回值
            options.html = html;
        }
        else {

            //设置模板#XX-template
            if (/^\#.*\-template$/.test(options.html)) {
                options.html = $(options.html).html(); //设置html options.html 必须是# ID样式。
            }
        } 

        tagetHtml = jquery(jquery.parseHTML(options.html));

        var win = jquery("<div></div>").appendTo('body').html(tagetHtml).attr('id', dialogId);

        //jquery.parse.parse(options.html);
        ///如果是url 则替换原来的html
        if (options.url)
            $.ajax({
                async: false, url: options.url, success: function (d) {
                    tagetHtml = jquery($.parseHTML(d));
                    win.empty().html(tagetHtml);
                }
            });

        //注册按钮
        if (!options.buttons) {
            defaultButtons = [{
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                  

                    if (options.submit)
                    {
                        options.submit(win);
                        //viewModel.submmit.call(options.submmit, win);
                        
                    }
                     
                }
            }, {
                text: '关闭',
                iconCls: 'icon-cancel',
                handler: function () {

                    win.dialog('close');
                }

            }
            ];

            options.buttons = defaultButtons;
        }
       
        //弹出对话框
        var dialog = win.dialog(options);
         
        viewModel = options.viewModel(win,options.vp);
        //注册解析完成事件
        jquery.parser.onComplete = function () {

            //判断是否knockout
            if ("undefined" === typeof ko)
                viewModel;
            else
                ko.applyBindings(viewModel, win[0]);

            jquery.parser.onComplete = jquery.noop;
        };

        dialog.model = viewModel; //返回model
      
      
        //解析html
         jquery.parser.parse(dialog);

        return dialog;
        



    };


    /*
    * 扩展 ajax，设置默认dataType,contentType: 为json格式
    @param {options}  jquery ajax options 选项
    */
    ut.ajax = function (options) {


        var defaultOptions = { 
            dataType: 'json',
            contentType: 'application/json',
            error: function (e) {
                var msg = e.responseText;
                var ret = msg.match(/^{\"Message\":\"(.*)\",\"ExceptionMessage\":\"(.*)\",\"ExceptionType\":.*/);
                if (ret != null) {
                    msg = (ret[1] + ret[2]).replace(/\\"/g, '"').replace(/\\r\\n/g, '<br/>').replace(/dbo\./g, '');
                }
                else {
                    try { msg = $(msg).text() || msg; }
                    catch (ex) { }
                } 
                $.message('错误', msg, 'error');
            }
        };

        $.ajax($.extend(defaultOptions,options));
    };

    ut.query = function (elementTab) {
        var query = $;
        if ($(document).find(elementTab).length == 0 && elementTab!=document) {
            if ($(parent.document).find(elementTab)) {
                query = parent.$;
            }
        }
        return query;
    };
    /**
	 * json格式转树状结构
	 * @param   {json}      json数据
	 * @param   {String}    id的字符串
	 * @param   {String}    父id的字符串
	 * @param   {String}    children的字符串
	 * @return  {Array}     数组
	 */
    ut.toTreeData = function (a, idStr, pidStr, childrenStr) {

        var r = [],
		hash = {},
		len = (a || []).length;
        for (var i = 0; i < len; i++) {
            hash[a[i][idStr]] = a[i];
        }
        for (var j = 0; j < len; j++) {
            var aVal = a[j],
			hashVP = hash[aVal[pidStr]];
            if (hashVP) {
                !hashVP[childrenStr] && (hashVP[childrenStr] = []);
                hashVP[childrenStr].push(aVal);
            } else {
                r.push(aVal);
            }
        }
        return r;

    };

    //性别列表
    ut.sexdata = [{
        'value': '0',
        'text': '男'
    }, {
        'value': '1',
        'text': '女'
    }
    ];

    ///格式化性别
    ut.sextdataFormatter = function (value, row, index) {

        if (value == null)
            return "";
        for (var item in ut.sexdata) {
            if (ut.sexdata[item].value == value) {
                return ut.sexdata[item].text;
            }
            //console.log(ut.sexdata[item]);
        }

    };
    //alert(  ut.sextdataFormatter("1"));
    //设置选择中的图片
    ut.setChecbox = function (value, row, index) {
        //console.log(typeof value);
        if (typeof value == 'boolean')
            return '<img src="/Content/Images/' + (value == true ? "checkmark.gif" : "checknomark.gif") + '"/>';
        else
            return '<img src="/Content/Images/' + (value == 'true' ? "checkmark.gif" : "checknomark.gif") + '"/>';
    };

    ///日期格式化
    ut.formatDate = function (v, format) {
        if (!v)
            return "";
        var d = v;
        if (typeof v === 'string') {
            if (v.indexOf("/Date(") > -1)
                d = new Date(parseInt(v.replace("/Date(", "").replace(")/", ""), 10));
            else
                d = new Date(Date.parse(v.replace(/-/g, "/").replace("T", " ").split(".")[0])); //.split(".")[0] 用来处理出现毫秒的情况，截取掉.xxx，否则会出错
        }
        var o = {
            "M+": d.getMonth() + 1, //month
            "d+": d.getDate(), //day
            "h+": d.getHours(), //hour
            "m+": d.getMinutes(), //minute
            "s+": d.getSeconds(), //second
            "q+": Math.floor((d.getMonth() + 3) / 3), //quarter
            "S": d.getMilliseconds() //millisecond
        };
        if (/(y+)/.test(format)) {
            format = format.replace(RegExp.$1, (d.getFullYear() + "").substr(4 - RegExp.$1.length));
        }
        for (var k in o) {
            if (new RegExp("(" + k + ")").test(format)) {
                format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
            }
        }
        return format;
    };

    ut.yyymmdd=function(val)
    {
        return ut.formatDate(val, 'yyyy-MM-dd');
    }
   
    ut.yyymmddhhss=function(val)
    {
        return ut.formatDate(val, 'yyyy-MM-dd hh:mm:ss');
    }

    /**
	 * 格式化数字显示方式
	 * 用法
	 * formatNumber(12345.999,'#,##0.00');
	 * formatNumber(12345.999,'#,##0.##');
	 * formatNumber(123,'000000');
	 */
    ut.formatNumber = function (v, pattern) {
        if (v == null)
            return v;
        var strarr = v ? v.toString().split('.') : ['0'];
        var fmtarr = pattern ? pattern.split('.') : [''];
        var retstr = '';
        // 整数部分
        var str = strarr[0];
        var fmt = fmtarr[0];
        var i = str.length - 1;
        var comma = false;
        for (var f = fmt.length - 1; f >= 0; f--) {
            switch (fmt.substr(f, 1)) {
                case '#':
                    if (i >= 0)
                        retstr = str.substr(i--, 1) + retstr;
                    break;
                case '0':
                    if (i >= 0)
                        retstr = str.substr(i--, 1) + retstr;
                    else
                        retstr = '0' + retstr;
                    break;
                case ',':
                    comma = true;
                    retstr = ',' + retstr;
                    break;
            }
        }
        if (i >= 0) {
            if (comma) {
                var l = str.length;
                for (; i >= 0; i--) {
                    retstr = str.substr(i, 1) + retstr;
                    if (i > 0 && ((l - i) % 3) == 0)
                        retstr = ',' + retstr;
                }
            } else
                retstr = str.substr(0, i + 1) + retstr;
        }
        retstr = retstr + '.';
        // 处理小数部分
        str = strarr.length > 1 ? strarr[1] : '';
        fmt = fmtarr.length > 1 ? fmtarr[1] : '';
        i = 0;
        for (var f = 0; f < fmt.length; f++) {
            switch (fmt.substr(f, 1)) {
                case '#':
                    if (i < str.length)
                        retstr += str.substr(i++, 1);
                    break;
                case '0':
                    if (i < str.length)
                        retstr += str.substr(i++, 1);
                    else
                        retstr += '0';
                    break;
            }
        }
        return retstr.replace(/^,+/, '').replace(/\.$/, '');
    };


    /*
    * 比较两个对象值是不是相等  
    * param {v1} 对象1
    * param {v2} 对象2
    */
    ut.compareObject = function (v1, v2) {
        var countProps = function (obj) {
            var count = 0;
            for (k in obj) if (obj.hasOwnProperty(k)) count++;
            return count;
        };

        if (typeof (v1) !== typeof (v2)) {
            return false;
        }

        if (typeof (v1) === "function") {
            return v1.toString() === v2.toString();
        }

        if (v1 instanceof Object && v2 instanceof Object) {
            if (countProps(v1) !== countProps(v2)) {
                return false;
            }
            var r = true;
            for (k in v1) { 
                r = ut.compareObject(v1[k], v2[k]);
                if (!r) {
                    return false;
                }
            }
            return true;
        } else {
            return v1 === v2;
        }
    };



    /*
    * 获取两个对象的差集
    * param {arr1} 对象1
    * param {arr2} 对象2
    */
    ut.minusArray = function (arr1, arr2) {
        var arr = [];
        for (var i in arr1) {
            var b = true;
            for (var j in arr2) {
                if (ut.compareObject(arr1[i], arr2[j])) {
                    b = false;
                    break;
                }
            }
            if (b) {
                arr.push(arr1[i]);
            }
        }
        return arr;
    };

    /*
     复制新的属性
    */
    ut.copyProperty = function (obj, sourcePropertyName, newPropertyName, overWrite) {
        if (obj instanceof Array || Object.prototype.toString.call(obj) === "[object Array]") {
            for (var k in obj)
                ut.copyProperty(obj[k], sourcePropertyName, newPropertyName);
        }
        else if (typeof obj === 'object') {
            if (sourcePropertyName instanceof Array || Object.prototype.toString.call(sourcePropertyName) === "[object Array]") {
                for (var i in sourcePropertyName) {
                    ut.copyProperty(obj, sourcePropertyName[i], newPropertyName[i]);
                }
            }
            else if (typeof sourcePropertyName === 'string') {
                if ((obj[newPropertyName] && overWrite) || (!obj[newPropertyName]))
                    obj[newPropertyName] = obj[sourcePropertyName];
            }
        }
        return obj;
    };


    ut.eachTreeRow = function (treeData, eachHandler) {
        for (var i in treeData) {
            if (eachHandler(treeData[i]) == false) break;
            if (treeData[i].children)
                ut.eachTreeRow(treeData[i].children, eachHandler);
        }
    };

    ut.isInChild = function (treeData, pid, id) {
        var isChild = false;
        ut.eachTreeRow(treeData, function (curNode) {
            if (curNode.id == pid) {
                ut.eachTreeRow([curNode], function (row) {
                    if (row.id == id) {
                        isChild = true;
                        return false;
                    }
                });
                return false;
            }
        });
        return isChild;
    };

    /**
    * 编辑DataGrid
    * @param   {grid}      datagrid elementTab
    */

    ut.editGridViewModel = function (grid) {
        var self = this;
        this.begin = function (index, row) {
            if (index == undefined || typeof index === 'object') {
                row = grid.datagrid('getSelected');
                index = grid.datagrid('getRowIndex', row);
            }
            self.editIndex = self.ended() ? index : self.editIndex;
            grid.datagrid('selectRow', self.editIndex).datagrid('beginEdit', self.editIndex);
        };
        this.ended = function () {
            if (self.editIndex == undefined) return true;
            if (grid.datagrid('validateRow', self.editIndex)) {
                grid.datagrid('endEdit', self.editIndex);
                self.editIndex = undefined;
                return true;
            }
            grid.datagrid('selectRow', self.editIndex);
            return false;
        };
        this.addnew = function (rowData) {
            if (self.ended()) {
                if (Object.prototype.toString.call(rowData) != '[object Object]') rowData = {};
                //rowData = $.extend({ _isnew: true }, rowData);
                grid.datagrid('appendRow', rowData);
                self.editIndex = grid.datagrid('getRows').length - 1;
                grid.datagrid('selectRow', self.editIndex);
                self.begin(self.editIndex, rowData);
            }
        };
        this.deleterow = function () {
            var selectRow = grid.datagrid('getSelected');
            if (selectRow) {


                var selectIndex = grid.datagrid('getRowIndex', selectRow);
                if (selectIndex == self.editIndex) {
                    grid.datagrid('cancelEdit', self.editIndex);
                    self.editIndex = undefined;
                }
                grid.datagrid('deleteRow', selectIndex);
            }
        };
        this.reject = function () {
             
                grid.datagrid('rejectChanges'); 
        
        };
        this.accept = function () {
            grid.datagrid('acceptChanges');
            var rows = grid.datagrid('getRows');
            //for (var i in rows) delete rows[i]._isnew;
        };

        /*
         opts ajax url
        */
        this.save = function (opts) {

            if (self.ended()) {
                var rows = grid.datagrid('getChanges');
                if (rows.length) {
                    var inserted = grid.datagrid('getChanges', 'inserted');
                    var deleted = grid.datagrid('getChanges', 'deleted');
                    var updated = grid.datagrid('getChanges', 'updated');
                    var effectRow = new Object();
                    if (inserted.length) {
                        effectRow["inserted"] = JSON.stringify(inserted);
                    }
                    if (deleted.length) {
                        effectRow["deleted"] = JSON.stringify(deleted);
                    }
                    if (updated.length) {
                        effectRow["updated"] = JSON.stringify(updated);
                    }

                    var options = $.extend({
                        type: 'post', 
                        data: JSON.stringify(effectRow),
                        contentType: 'application/json',
                        success: function (d) {

                            if (d.status == false) {
                                parent.$.messager.alert("错误", d.msg, 'error');
                            }
                            else {
                                self.accept();
                               
                            }
                        }
                    }, opts);
                    $.ajax(options);

                }
            }
        };
      
       
    };

    /**
    * 编辑TreeGrid
    * @param   {grid}      treegrid elementTab
    */

    ut.editTreeGridViewModel = function (grid, opts) {

        var self = this, idField = grid.idField;
       
        this.begin = function () {

            opts = $.extend(opts, opts || {});

            
            var row = grid.treegrid('getSelected');
            if (row) {

                if (opts.combotree)
                {
                    //取得父节点数据  
                    var data_tree = grid.treegrid('getData');
                    if (data_tree[0]._id && data_tree[0]._id == '0') { }
                    else
                    { data_tree.unshift({ '_id': '0', 'text': '' }); }
                    //获取datagridoptions 属性
                    var gridOpt = $.data(grid.$element()[0], "datagrid").options;
                    //获取pid 列
                    //var col = $.grep(gridOpt.columns[0], function (n) { return n.field == 'pid' })[0]; 
                    var col = $.grep(gridOpt.columns[0], function (n) { return n.field == opts.combotree.col })[0];
                    col.editor = { 'type': 'combotree', options: { 'data': data_tree } };
                    col.editor.options.onBeforeSelect = function (node) {
                        var isChild = ut.isInChild(data_tree, row._id, node.id);
                        if(isChild)
                        $.messager.alert('warning', '不能将自己或下级设为上级节点', 'error');
                        return !isChild;
                    }; 
                }
               
                //开始编辑行数据
                grid.treegrid('beginEdit', row._id);
                self.edit_id = row._id;

                if(opts.lookup)
                {
                    var eds = grid.treegrid('getEditors', row._id);
                    var edt = function (field) { return $.grep(eds, function (n) { return n.field == field })[0]; };
                    self.afterCreateEditors(edt);
                }
             
            }

        };


        this.afterCreateEditors = function (editors) {

            //var iconInput = editors("iconCls").target;
            var iconInput = editors(opts.lookup.col).target;
            iconInput.textbox({
                onClickButton: function () {

                    CH.utils.dialog({
                                    url: '/Content/page/icon.html',
                                    title:'选择图标',
                                    width: 700,
                                    height: 500,
                                    viewModel: function (w)
                                    { 
                                        w.find('#iconlist').css("padding", "5px");
                                        w.find('#iconlist li').attr('style', 'float:left;border:1px solid #fff; line-height:20px; margin-right:4px;width:16px;cursor:pointer').hover(function () {
                                            $(this).css({ 'border': '1px solid red' });
                                        }, function () {
                                            $(this).css({ 'border': '1px solid #fff' });
                                        }).click(function(){
                                 
                                            iconInput.textbox('setValue', $(this).find('span').attr('class').split(" ")[1]);
                                            w.dialog('close');
                                        });
                                    }
                                });
                }
            });
           

        };


        this.ended = function () {
            var edit_id = self.edit_id;
            if (!!edit_id) {
                if (grid.treegrid('validateRow', edit_id)) { //通过验证
                    grid.treegrid('endEdit', edit_id);
                    self.edit_id = undefined;
                }
                else { //未通过验证
                    grid.treegrid('select', edit_id);
                    return false;
                }
            }
            return true;
        };

        this.addnew = function () {

            self.begin();//防止不验证
            if (self.ended()) {
                var row = { _id: ut.uuid(),id:'', text: '', isEnable: false };
                grid.treegrid('append', { parent: '', data: [row] });
                grid.treegrid('select', row._id); 
                grid.$element().data("datagrid").insertedRows.push(row);
                self.ended();
            }
        };
        this.deleterow = function () {
            var row = grid.treegrid('getSelected');
            if (row) {
                grid.$element().treegrid('remove', row._id);
                //grid.$element().data("datagrid").deletedRows.push(row);
            }
        };
        this.reject = function () {
            throw '未实现此方法';
        };
        this.accept = function () {
            grid.treegrid('acceptChanges');
           
        };
        this.getChanges = function () {
            
        };

        this.save = function (options) {
              
            self.ended();
                var rows = grid.$element().datagrid('getChanges');
                if (rows.length) {
                    var inserted = grid.$element().datagrid('getChanges', 'inserted');
                    var deleted = grid.$element().datagrid('getChanges', 'deleted');
                    var updated = grid.$element().datagrid('getChanges', 'updated');
                    var effectRow = new Object();
                    if (inserted.length) {
                        effectRow["inserted"] = JSON.stringify(inserted);
                    }
                    if (deleted.length) {
                        effectRow["deleted"] = JSON.stringify(deleted);
                    }
                    if (updated.length) {
                        effectRow["updated"] = JSON.stringify(updated);
                    }

                    var options = $.extend({
                        type: 'post',
                        data: JSON.stringify(effectRow),
                        contentType: 'application/json',
                        success: function (d) {

                            if (d.status == false) {
                                $.messager.alert("错误", d.msg, 'error');
                            }
                            else {
                                self.accept();

                            }
                        }
                    }, options);
                    $.ajax(options);
                }
           
        };
       
    };



    ut.filterProperties = function (obj, props, ignore) {
        var ret;
        if (obj instanceof Array || Object.prototype.toString.call(obj) === "[object Array]") {
            ret = [];
            for (var k in obj) {
                ret.push(ut.filterProperties(obj[k], props, ignore));
            }
        }
        else if (typeof obj === 'object') {
            ret = {};
            if (ignore) {
                var map = {};
                for (var k in props)
                    map[props[k]] = true;

                for (var i in obj) {
                    if (!map[i]) ret[i] = obj[i];
                }
            }
            else {
                for (var i in props) {
                    var arr = props[i].split(" as ");
                    ret[arr[1] || arr[0]] = obj[arr[0]];
                }
            }
        }
        else {
            ret = obj;
        }
        return ret;
    };


    /*
    http://blog.csdn.net/mr_raptor/article/details/52280753
    // 8 character ID (base=2)
uuid(8, 2)  //  "01001010"
// 8 character ID (base=10)
uuid(8, 10) // "47473046"
// 8 character ID (base=16)
uuid(8, 16) // "098F4D35"
    */
    ut.uuid = function (len, radix) {
        var chars = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz'.split('');
        var uuid = [], i;
        radix = radix || chars.length;

        if (len) {
            // Compact form
            for (i = 0; i < len; i++) uuid[i] = chars[0 | Math.random() * radix];
        } else {
            // rfc4122, version 4 form
            var r;

            // rfc4122 requires these characters
            uuid[8] = uuid[13] = uuid[18] = uuid[23] = '-';
            uuid[14] = '4';

            // Fill in random data.  At i==19 set the high bits of clock sequence as
            // per rfc4122, sec. 4.1.5
            for (i = 0; i < 36; i++) {
                if (!uuid[i]) {
                    r = 0 | Math.random() * 16;
                    uuid[i] = chars[(i == 19) ? (r & 0x3) | 0x8 : r];
                }
            }
        }

        return uuid.join('');
    };



    //字符串转16进制

    ut.strToHexCharCode = function (str) {
        if (str === "")
            return "";
        var hexCharCode = [];
        hexCharCode.push("0x");
        for (var i = 0; i < str.length; i++) {
            hexCharCode.push((str.charCodeAt(i)).toString(16));
        }
        return hexCharCode.join("");
    };

 

   // 16进制转字符串

    ut.hexCharCodeToStr = function (hexCharCodeStr) {
        var trimedStr = hexCharCodeStr.trim();
        var rawStr =
        trimedStr.substr(0, 2).toLowerCase() === "0x"
        ?
        trimedStr.substr(2)
        :
        trimedStr;
        var len = rawStr.length;
        if (len % 2 !== 0) {
            alert("Illegal Format ASCII Code!");
            return "";
        }
        var curCharCode;
        var resultStr = [];
        for (var i = 0; i < len; i = i + 2) {
            curCharCode = parseInt(rawStr.substr(i, 2), 16); // ASCII Code Value
            resultStr.push(String.fromCharCode(curCharCode));
        }
        return resultStr.join("");
    };


    return ut;

}
	(CH.utils || {}));

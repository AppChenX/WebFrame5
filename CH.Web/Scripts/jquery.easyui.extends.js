/*
疯狂秀才（1055818239） 
version: 0.01
*/
(function ($) {

    // 创建控件DOM
    function create(target) {
        var id = $(target).attr('id');

        if (!id) {
            id = 'lookup_' + new Date().getTime();
            $(target).attr('id', id);
        }

        $(target).addClass('combo-f').hide();

        var lookup = $('<span class="combo"></span>').insertAfter(target);
        var textbox = $('<input type="text" class="combo-text" />').appendTo(lookup);
        var arrow = $("<span><span class=\"combo-arrow \"></span></span>").appendTo(lookup);
        var valbox = $("<input type=\"hidden\" class=\"combo-value\">").appendTo(lookup);

        lookup.addClass('lookup');



        var state = $.data(target, 'lookup');

        // 添加图标
        if (state.options.iconCls) {
            arrow.find('.combo-arrow').addClass(state.options.iconCls);
        }
        else {
            arrow.find('.combo-arrow').addClass('icon-search');
        }

        // 创建 dialog
        var _dialogOpts = {
            closed: true,
            title: state.options.title,
            onClose: function () {
                state.dialog.dialog('destroy');
                state.dialog = null;
            }
        }

        var name = $(target).attr("name");
        if (name) {
            lookup.find("input.combo-value").attr("name", name);
            $(target).removeAttr("name").attr("comboName", name);
        }
        textbox.attr("autocomplete", "off");

        arrow.on('click', function () {

            if (!state.dialog) {
                var did = 'dialog_' + id + '-' + new Date().getTime();
                _dialogOpts = $.extend({}, state.options.dialog, _dialogOpts);

                var _dialog = $('<div/>').attr('id', did).dialog(_dialogOpts);
                state.dialog = _dialog;
            }

            state.dialog.dialog('open');
        });

        state.textbox = textbox;
        state.valbox = valbox;


    }

    $.fn.lookup = function (options, param) {
        if (typeof options == 'string') {
            var method = $.fn.lookup.methods[options];
            if (method) {
                return method(this, param);
            } else {
                return this.lookup(options, param);
            }
        }

        options = options || {};

        return this.each(function () {
            var state = $.data(this, 'lookup');
            if (state) {
                $.extend(state.options, options);
                create(this);
            }
            else {
                $.data(this, 'lookup', { options: $.extend({}, $.fn.lookup.defaults, options) });
                create(this);
            }
        })

    }


    $.fn.lookup.methods = {
        open: function () { },
        close: function (jq) {
            return jq.each(function () {
                var state = $.data(this, 'lookup');
                state.dialog.dialog('close');
            });
        },
        setValue: function (jq, val) {
            return jq.each(function () {
                var state = $.data(this, 'lookup');
                state.valbox.val(val);
            });

        },
        getValue: function (jq) {
            var state = $.data(jq[0], 'lookup');
            return state.valbox.val();

        },
        setText: function (jq, text) {
            return jq.each(function () {
                var state = $.data(this, 'lookup');
                state.textbox.val(text);
            });

        },
        getText: function (jq) {
            var state = $.data(jq[0], 'lookup');
            return state.textbox.val();
        }
    }

    $.fn.lookup.defaults = {
        iconCls: '',
        width: 120, height: 'auto',
        dialog: {
            title: '选择',
            width: 400, height: 300
        },
        onOpened: function () {
        }
    }

})(jQuery);
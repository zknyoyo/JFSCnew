(function () {
    $('#exchange').click(function () {
        if ($('.confirm-box').css('display') == 'none') {
            $('.confirm-box').show();
            var price = $('#gift_id').attr('Gprice');
            var amount = $('#amount').val();
            var sum = price * amount;
            var exchange_info =  price + '&nbsp;*&nbsp;' + amount + '&nbsp;=&nbsp;' + sum ;
            $('#confirm-info').html(exchange_info)
        }
    });
    $('.confirm-box .confirm-button').click(function () {
        var amount = $('#amount').val();
        var gift_id = $('#gift_id').attr('Gid');
        $.ajax({
            type: 'post',
            method: 'GET',
            dataType: 'json',
            url: '../../home/exchange',
            data: { gift_id: gift_id, amount: amount },
            success: function (data) {
                if (data.result){
                    $('.confirm-box').hide();
                    var newPoints = $('#points').html() - data.price * data.amount;
                    $('#points').html(newPoints);
                    location.href = '/';
                    alert("兑换成功！");
                }
                else if(data.result=='tooless'){
                    $('.confirm-box').hide();
                    alert("分数不够！兑换失败。");
                }
                else {
                    $('.confirm-box').hide();
                    alert("兑换失败，请返回礼品列表！");
                }
            },
            error: function (response) {
                alert(response);
            }
        });
    });
    $('.confirm-box .cancel-button').click(function () {
        $(this).parent().hide();
    });
    $('.amount-plus').click(function () {
        var amount = $('#amount').val();
        $('#amount').val(++amount);
        if(amount==1)
        {
            $('.amount-minus').removeClass('amount-unable');
        }
    });
    $('.amount-minus').click(function () {
        var amount = $('#amount').val();
        if (amount != 0)
        {
            $('#amount').val(--amount);
            if (amount == 0)
            {
                $(this).addClass('amount-unable');
            }
        }
    });
})();
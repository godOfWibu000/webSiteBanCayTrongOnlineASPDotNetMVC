// Menu
$(document).ready(function () {
    $('#toggle').click(function () {
        $('#menu').slideToggle();
    });
})

//Up-top
window.addEventListener('scroll', function () {
    var header = document.querySelector("header");
    var uptop = document.getElementById("up-top");
    header.classList.toggle("sticky", window.scrollY > 0);
    uptop.classList.toggle("up-top-top", window.scrollY > 0);
})

$("#up-top").click(function () {
    $('html, body').animate({ scrollTop: 0 }, 300);
});

//Share
function showbtnshare() {
    var style = document.getElementById('share').style.display;
    if (style == 'none') {
        document.getElementById('share').style.display = 'block';
    } else {
        document.getElementById('share').style.display = 'none';
    }
}

//Rate
function rate() {
    if (document.getElementById('username').innerHTML != ' Đăng nhập ')
        yeuThich();

    var star1 = document.getElementsByClassName('star1');
    var star2 = document.getElementsByClassName('star2');
    var star3 = document.getElementsByClassName('star3');
    var star4 = document.getElementsByClassName('star4');
    var star5 = document.getElementsByClassName('star5');
    var halfstar1 = document.getElementsByClassName('halfstar1');
    var halfstar2 = document.getElementsByClassName('halfstar2');
    var halfstar3 = document.getElementsByClassName('halfstar3');
    var halfstar4 = document.getElementsByClassName('halfstar4');
    var halfstar5 = document.getElementsByClassName('halfstar5');
    var numberstar = document.getElementsByClassName('numberstar');

    for (var i = 0; i <= numberstar.length; i++) {
        if (numberstar[i].innerHTML == '1') {
            star1[i].style.opacity = '1';
        }
        else if (numberstar[i].innerHTML == '2') {
            star1[i].style.opacity = '1';
            star2[i].style.opacity = '1';
        }
        else if (numberstar[i].innerHTML == '3') {
            star1[i].style.opacity = '1';
            star2[i].style.opacity = '1';
            star3[i].style.opacity = '1';
        }
        else if (numberstar[i].innerHTML == '4') {
            star1[i].style.opacity = '1';
            star2[i].style.opacity = '1';
            star3[i].style.opacity = '1';
            star4[i].style.opacity = '1';
        }
        else if (numberstar[i].innerHTML == '5') {
            star1[i].style.opacity = '1';
            star2[i].style.opacity = '1';
            star3[i].style.opacity = '1';
            star4[i].style.opacity = '1';
            star5[i].style.opacity = '1';
        }
        for (var j = 1; j <= 9; j++) {
            if (numberstar[i].innerHTML == '1.' + j) {
                star1[i].style.opacity = '1';
                halfstar2[i].style.opacity = '1';
                break;
            }
            else if (numberstar[i].innerHTML == '2.' + j) {
                star1[i].style.opacity = '1';
                star2[i].style.opacity = '1';
                halfstar3[i].style.opacity = '1';
                break;
            }
            else if (numberstar[i].innerHTML == '3.' + j) {
                star1[i].style.opacity = '1';
                star2[i].style.opacity = '1';
                star3[i].style.opacity = '1';
                halfstar4[i].style.opacity = '1';
                break;
            }
            else if (numberstar[i].innerHTML == '4.' + j) {
                star1[i].style.opacity = '1';
                star2[i].style.opacity = '1';
                star3[i].style.opacity = '1';
                star4[i].style.opacity = '1';
                halfstar5[i].style.opacity = '1';
                break;
            }
        }
    }
}

function yeuThich() {
    var tfFavorite = document.getElementById('tf-favorite');
    if (tfFavorite.value == 'OK') {
        document.getElementById('heart1').style.display = 'none';
        document.getElementById('tooltiptext').innerHTML = 'Bỏ thích';
    }
    else if (tfFavorite.value == 'NO') {
        document.getElementById('heart2').style.display = 'none';
    }
}

// Login
function showLogin() {
    document.getElementById('loginFrame').style.display = 'block';
}

function closeLogin() {
    document.getElementById('loginFrame').style.display = 'none';
}
//Hien thi password
function showpass() {
    var password = document.getElementById('password');
    var eye = document.getElementById('eye');
    var hideeye = document.getElementById('hide-eye');

    if (password.type == 'password') {
        password.type = 'text';
        eye.style.opacity = '1';
        hideeye.style.opacity = '0';
    } else {
        password.type = 'password';
        eye.style.opacity = '0';
        hideeye.style.opacity = '1';
    }
}
//Kiem tra dang nhap
function kTraDangNhap() {
    var password = document.getElementById('password');
    var message = document.getElementById('message');
    if (password.value.length < 8) {
        message.innerHTML = 'Mật khẩu phải từ 8 ký tự trở lên!';
        message.style.color = 'red';

        return false;
    }
}

//Xac nhan xoa san pham
function xoaSP() {
    document.getElementById('xacnhanxoa').style.display = 'block';
}

function huyXoa() {
    document.getElementById('xacnhanxoa').style.display = 'none';
}

//Them san pham
function themSP() {
    document.getElementById('themSP').style.display = 'block';
}
function thoatThemSP() {
    document.getElementById('themSP').style.display = 'none';
}

//Loc san pham
$(document).ready(function () {
    $('#locSP').on('keyup', function (event) {
        event.preventDefault();
        /* Act on the event */
        var tukhoa = $(this).val().toLowerCase();
        $('#sp tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(tukhoa) > -1);
        });
    });
});

//Hien thi don hang
function dsDonHang() {
    var dsDonHang = document.getElementById("ds-donhang");
    if (dsDonHang.style.display == 'none') {
        dsDonHang.style.display = 'block';
    } else {
        dsDonHang.style.display = 'none';
    }
}

//Them sp vao gio hang
function congSp() {
    var soSP = document.getElementById('so-sp').value;
    soSP++;
    document.getElementById('so-sp').value = soSP;
    var donGia = document.getElementById('don-gia').value;
    var soTien = soSP * donGia;
    document.getElementById('so-tien').value = soTien;
    document.getElementById('so-tien').style.width = '37px';
}

function truSp() {
    var soSP = document.getElementById('so-sp').value;
    if (soSP > 1) {
        soSP--;
        document.getElementById('so-sp').value = soSP;
        var donGia = document.getElementById('don-gia').value;
        var soTien = soSP * donGia;
        document.getElementById('so-tien').value = soTien;

        if (soTien < 100)
            document.getElementById('so-tien').style.width = '25px';
        else
            document.getElementById('so-tien').style.width = '37px';
    }
}

function choXacNhan() {
    document.getElementById('donhang-choxacnhans').style.display = 'block';
    document.getElementById('donhang-dangkiemtras').style.display = 'none';
    document.getElementById('donhang-danggiaos').style.display = 'none';
    document.getElementById('donhang-dagiaos').style.display = 'none';

    document.getElementById('choxacnhan-btn').style.borderBottom = '2px solid red';
    document.getElementById('dangkiemtra-btn').style.border = 'none';
    document.getElementById('danggiao-btn').style.border = 'none';
    document.getElementById('dagiao-btn').style.border = 'none';
}

function dangKiemTra() {
    document.getElementById('donhang-dangkiemtras').style.display = 'block';
    document.getElementById('donhang-choxacnhans').style.display = 'none';
    document.getElementById('donhang-danggiaos').style.display = 'none';
    document.getElementById('donhang-dagiaos').style.display = 'none';

    document.getElementById('dangkiemtra-btn').style.borderBottom = '2px solid red';
    document.getElementById('choxacnhan-btn').style.border = 'none';
    document.getElementById('danggiao-btn').style.border = 'none';
    document.getElementById('dagiao-btn').style.border = 'none';
}

function dangGiao() {
    document.getElementById('donhang-danggiaos').style.display = 'block';
    document.getElementById('donhang-choxacnhans').style.display = 'none';
    document.getElementById('donhang-dangkiemtras').style.display = 'none';
    document.getElementById('donhang-dagiaos').style.display = 'none';

    document.getElementById('danggiao-btn').style.borderBottom = '2px solid red';
    document.getElementById('choxacnhan-btn').style.border = 'none';
    document.getElementById('dangkiemtra-btn').style.border = 'none';
    document.getElementById('dagiao-btn').style.border = 'none';
}

function daGiao() {
    document.getElementById('donhang-dagiaos').style.display = 'block';
    document.getElementById('donhang-choxacnhans').style.display = 'none';
    document.getElementById('donhang-dangkiemtras').style.display = 'none';
    document.getElementById('donhang-danggiaos').style.display = 'none';

    document.getElementById('dagiao-btn').style.borderBottom = '2px solid red';
    document.getElementById('choxacnhan-btn').style.border = 'none';
    document.getElementById('dangkiemtra-btn').style.border = 'none';
    document.getElementById('danggiao-btn').style.border = 'none';
}


function getDate() {
    var d = new Date();

    var date = d.getDate() + '/' + (d.getMonth() + 1) + '/' + d.getFullYear();
    document.getElementById('date').value = date;
}

//Quan ly tai khoan
function quanLyTaiKhoan() {
    document.getElementById('quanlyyeuthich-btn').style.color = 'black';
    document.getElementById('quanlydanhgia-btn').style.color = 'black';
    document.getElementById('quanlyttcanhan-btn').style.color = 'black';
    document.getElementById('quanlydonhang-btn').style.color = 'black';
    document.getElementById('quanlytaikhoan-btn').style.color = 'var(--main-color1)';

    document.getElementById('quanly-ttcanhan').style.display = 'none';
    document.getElementById('quanly-dh').style.display = 'none';
    document.getElementById('quanly-yeuthich').style.display = 'none';
    document.getElementById('quanly-danhgia').style.display = 'none';
    document.getElementById('quanly-taikhoan').style.display = 'block';
}

function quanLyTTCaNhan() {
    document.getElementById('quanlyyeuthich-btn').style.color = 'black';
    document.getElementById('quanlydanhgia-btn').style.color = 'black';
    document.getElementById('quanlytaikhoan-btn').style.color = 'black';
    document.getElementById('quanlydonhang-btn').style.color = 'black';
    document.getElementById('quanlyttcanhan-btn').style.color = 'var(--main-color1)';

    document.getElementById('quanly-taikhoan').style.display = 'none';
    document.getElementById('quanly-dh').style.display = 'none';
    document.getElementById('quanly-yeuthich').style.display = 'none';
    document.getElementById('quanly-danhgia').style.display = 'none';
    document.getElementById('quanly-ttcanhan').style.display = 'block';
}

function quanLyDH() {
    document.getElementById('quanlyyeuthich-btn').style.color = 'black';
    document.getElementById('quanlydanhgia-btn').style.color = 'black';
    document.getElementById('quanlytaikhoan-btn').style.color = 'black';
    document.getElementById('quanlyttcanhan-btn').style.color = 'black';
    document.getElementById('quanlydonhang-btn').style.color = 'var(--main-color1)';

    document.getElementById('quanly-taikhoan').style.display = 'none';
    document.getElementById('quanly-ttcanhan').style.display = 'none';
    document.getElementById('quanly-yeuthich').style.display = 'none';
    document.getElementById('quanly-danhgia').style.display = 'none';
    document.getElementById('quanly-dh').style.display = 'block';
}

function quanLyYeuThich() {
    document.getElementById('quanlydanhgia-btn').style.color = 'black';
    document.getElementById('quanlytaikhoan-btn').style.color = 'black';
    document.getElementById('quanlyttcanhan-btn').style.color = 'black';
    document.getElementById('quanlydonhang-btn').style.color = 'black';
    document.getElementById('quanlyyeuthich-btn').style.color = 'var(--main-color1)';

    document.getElementById('quanly-taikhoan').style.display = 'none';
    document.getElementById('quanly-ttcanhan').style.display = 'none';
    document.getElementById('quanly-dh').style.display = 'none';
    document.getElementById('quanly-danhgia').style.display = 'none';
    document.getElementById('quanly-yeuthich').style.display = 'block';
}

function quanLyDanhGia() {
    document.getElementById('quanlyyeuthich-btn').style.color = 'black';
    document.getElementById('quanlytaikhoan-btn').style.color = 'black';
    document.getElementById('quanlyttcanhan-btn').style.color = 'black';
    document.getElementById('quanlydonhang-btn').style.color = 'black';
    document.getElementById('quanlydanhgia-btn').style.color = 'var(--main-color1)';

    document.getElementById('quanly-taikhoan').style.display = 'none';
    document.getElementById('quanly-ttcanhan').style.display = 'none';
    document.getElementById('quanly-dh').style.display = 'none';
    document.getElementById('quanly-yeuthich').style.display = 'none';
    document.getElementById('quanly-danhgia').style.display = 'block';
}



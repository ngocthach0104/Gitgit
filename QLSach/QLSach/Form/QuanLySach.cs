using QLSach.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {
            InitializeComponent();
        }

        DBcontextQuanLySach context = new DBcontextQuanLySach();

        private void danhSachTheLoai(List<LoaiSach> listLoaiSach)
        {
            cmb_TheLoai.DataSource = context.LoaiSaches.ToList();
            cmb_TheLoai.DisplayMember = "TenLoai"; // Display the TenLoai property
            cmb_TheLoai.ValueMember = "MaLoai";
        }

        private void BindGrid(List<Sach> listSach)
        {
            dgv_DanhSachSach.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgv_DanhSachSach.Rows.Add();
                dgv_DanhSachSach.Rows[index].Cells[0].Value = item.MaSach;
                dgv_DanhSachSach.Rows[index].Cells[1].Value = item.TenSach;
                dgv_DanhSachSach.Rows[index].Cells[2].Value = item.NamXB;
                dgv_DanhSachSach.Rows[index].Cells[3].Value = item.LoaiSach.TenLoai;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                List<LoaiSach> listLoaiSach = context.LoaiSaches.ToList(); // Lấy danh sách các khoa
                List<Sach> listSach = context.Saches.ToList(); // Lấy danh sách sinh viên
                danhSachTheLoai(listLoaiSach);
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_DanhSachSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn từ DataGridView
                DataGridViewRow row = dgv_DanhSachSach.Rows[e.RowIndex];

                txt_MaSach.Text = row.Cells[0].Value.ToString();
                txt_TenSach.Text = row.Cells[1].Value.ToString();
                txt_NamXB.Text = row.Cells[2].Value.ToString();
                cmb_TheLoai.Text = row.Cells[3].Value.ToString();
            }
        }

        // Sự kiện click nút "Xóa"
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // Lấy mã sách từ TextBox hoặc từ DataGridView (tùy theo cách bạn hiện thực)
            string maSachToDelete = txt_MaSach.Text; // Ví dụ: Lấy mã sách từ TextBox

            // Kiểm tra xem mã sách đã tồn tại trong CSDL hay chưa
            var bookToDelete = context.Saches.FirstOrDefault(s => s.MaSach == maSachToDelete);

            if (bookToDelete != null)
            {
                // Hiển thị cảnh báo YES/NO
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Xóa sách từ CSDL
                    context.Saches.Remove(bookToDelete);
                    context.SaveChanges(); // Lưu thay đổi vào CSDL

                    // Cập nhật lại DataGridView sau khi xóa
                    List<Sach> updatedBooks = context.Saches.ToList();
                    BindGrid(updatedBooks);

                    // Xóa dữ liệu từ TextBox sau khi xóa thành công (tuỳ theo yêu cầu)
                    txt_MaSach.Text = string.Empty;
                    txt_TenSach.Text = string.Empty;
                    txt_NamXB.Text = string.Empty;
                    cmb_TheLoai.Text = string.Empty;
                }
            }
            else
            {
                // Thông báo "Sách cần xóa không tồn tại!"
                MessageBox.Show("Sách cần xóa không tồn tại!");
            }
        }

        // Sự kiện click cho nút "Thêm"
        private void btn_Them_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txt_MaSach.Text) || string.IsNullOrWhiteSpace(txt_TenSach.Text) || string.IsNullOrWhiteSpace(txt_NamXB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách, bao gồm năm xuất bản!");
                return; // Không thực hiện thêm mới nếu thiếu thông tin
            }

            // Kiểm tra số ký tự của mã sách
            if (txt_MaSach.Text.Length != 6)
            {
                MessageBox.Show("Mã sách phải có 6 ký tự!");
                return; // Không thực hiện thêm mới nếu mã sách không đúng độ dài
            }

            // Kiểm tra xem sách đã tồn tại trong CSDL dựa vào mã sách
            Sach existingBook = context.Saches.FirstOrDefault(s => s.MaSach == txt_MaSach.Text);

            if (existingBook != null)
            {
                // Thông báo "Sách đã tồn tại"
                MessageBox.Show("Sách đã tồn tại!");
            }
            else
            {
                // Sách chưa tồn tại, thực hiện thêm mới

                // Kiểm tra xem năm xuất bản hợp lệ (có đúng 4 ký tự số)
                if (txt_NamXB.Text.Length != 4)
                {
                    MessageBox.Show("Năm xuất bản phải có đúng 4 ký tự số!");
                    return; // Không thực hiện thêm mới nếu năm xuất bản không hợp lệ
                }

                Sach newBook = new Sach();
                newBook.MaSach = txt_MaSach.Text;
                newBook.TenSach = txt_TenSach.Text;

                // Kiểm tra xem năm xuất bản là số hợp lệ
                int namXB;
                if (int.TryParse(txt_NamXB.Text, out namXB))
                {
                    // Kiểm tra xem năm xuất bản là số hợp lệ và nằm trong khoảng từ 1900 đến năm hiện tại
                    if (namXB >= 1800 && namXB <= DateTime.Now.Year)
                    {
                        newBook.NamXB = namXB;
                    }
                    else
                    {
                        MessageBox.Show("Năm xuất bản không hợp lệ!");
                        return; // Không thực hiện thêm mới nếu năm xuất bản không hợp lệ
                    }
                }
                else
                {
                    MessageBox.Show("Năm xuất bản không hợp lệ!");
                    return; // Không thực hiện thêm mới nếu năm xuất bản không hợp lệ
                }

                // Lấy giá trị MaLoai từ ComboBox
                if (cmb_TheLoai.SelectedItem != null)
                {
                    LoaiSach selectedLoai = (LoaiSach)cmb_TheLoai.SelectedItem;
                    newBook.MaLoai = selectedLoai.MaLoai;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách!");
                    return; // Không thực hiện thêm mới nếu không chọn thể loại
                }

                // Thêm sách mới vào CSDL
                context.Saches.Add(newBook);

                // Lưu thay đổi vào CSDL
                try
                {
                    context.SaveChanges();
                    // Xuất thông báo "Thêm mới thành công"
                    MessageBox.Show("Thêm mới thành công");

                    // Cập nhật lại DataGridView
                    List<Sach> updatedBooks = context.Saches.ToList();
                    BindGrid(updatedBooks);

                    // Reset các thông tin nhập liệu sách
                    txt_MaSach.Text = string.Empty;
                    txt_TenSach.Text = string.Empty;
                    txt_NamXB.Text = string.Empty;
                    // Reset ComboBox thể hiện thông tin các loại sách
                    cmb_TheLoai.SelectedIndex = -1; // Chọn một giá trị mặc định hoặc -1 tùy vào thiết kế của bạn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Sự kiện click cho nút "Sửa"
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã sách không được rỗng
            if (string.IsNullOrWhiteSpace(txt_MaSach.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách!");
                return; // Không thực hiện sửa nếu thiếu mã sách
            }

            // Kiểm tra số ký tự của mã sách
            if (txt_MaSach.Text.Length != 6)
            {
                MessageBox.Show("Mã sách phải có 6 ký tự!");
                return; // Không thực hiện sửa nếu mã sách không đúng độ dài
            }

            // Tìm sách theo mã sách
            Sach book = context.Saches.FirstOrDefault(s => s.MaSach == txt_MaSach.Text);

            if (book != null)
            {
                // Kiểm tra thông tin bắt buộc
                if (string.IsNullOrWhiteSpace(txt_TenSach.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sách!");
                    return; // Không thực hiện sửa nếu thiếu tên sách
                }

                // Cập nhật thông tin sách từ các TextBox
                book.TenSach = txt_TenSach.Text;

                if (!string.IsNullOrWhiteSpace(txt_NamXB.Text))
                {
                    int namXB;
                    if (int.TryParse(txt_NamXB.Text, out namXB))
                    {
                        book.NamXB = namXB;
                    }
                    else
                    {
                        MessageBox.Show("Năm xuất bản không hợp lệ!");
                        return; // Không thực hiện sửa nếu năm xuất bản không hợp lệ
                    }
                }
                else
                {
                    book.NamXB = null; // Cho trường hợp năm xuất bản không được nhập
                }

                // Cập nhật lại ComboBox thể hiện thông tin loại sách nếu bạn cho phép sửa loại sách
                // Lấy giá trị MaLoai từ ComboBox
                if (cmb_TheLoai.SelectedItem != null)
                {
                    LoaiSach selectedLoai = (LoaiSach)cmb_TheLoai.SelectedItem;
                    book.MaLoai = selectedLoai.MaLoai;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại sách!");
                    return; // Không thực hiện sửa nếu không chọn thể loại
                }

                // Lưu thay đổi vào CSDL
                try
                {
                    context.SaveChanges();
                    // Xuất thông báo "Cập nhật thành công"
                    MessageBox.Show("Cập nhật thành công");

                    // Cập nhật lại DataGridView
                    List<Sach> updatedBooks = context.Saches.ToList();
                    BindGrid(updatedBooks);

                    // Reset các thông tin nhập liệu sách
                    txt_MaSach.Text = string.Empty;
                    txt_TenSach.Text = string.Empty;
                    txt_NamXB.Text = string.Empty;
                    // Reset ComboBox thể hiện thông tin các loại sách
                    cmb_TheLoai.SelectedIndex = 0; // Chọn một giá trị mặc định hoặc -1 tùy vào thiết kế của bạn
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                // Thông báo "Sách không tồn tại"
                MessageBox.Show("Sách không tồn tại!");
            }
        }

        private void txt_NamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự nhập vào nếu không phải là số
            }
        }
        
        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_TimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm và loại bỏ khoảng trắng

            // Tìm sách theo từ khóa
            List<Sach> result = context.Saches
                .Where(s =>
                    s.MaSach.Contains(keyword) || // Kiểm tra mã sách chứa từ khóa
                    s.TenSach.Contains(keyword) || // Kiểm tra tên sách chứa từ khóa
                    (s.NamXB.HasValue && s.NamXB.Value.ToString().Contains(keyword))) // Kiểm tra năm xuất bản chứa từ khóa
                .ToList();

            // Cập nhật DataGridView với kết quả tìm kiếm
            BindGrid(result);
        }
    }
}

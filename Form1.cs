using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BDTT
{
    public partial class Form1 : Form
    {
        DataTable dt_All = new DataTable();



        public Form1()
        {
            dt_All.Columns.Add("ID", typeof(string));
            dt_All.Columns.Add("Noidung", typeof(string));
            dt_All.Columns.Add("TienMin", typeof(string));
            dt_All.Columns.Add("TienMax", typeof(string));
            dt_All.Columns.Add("Bosung", typeof(string));


            dt_All.Rows.Add("1", "Không chú ý quan sát, điều khiển xe máy chạy quá tốc độ quy định gây tai nạn giao thông", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("2", "Không giảm tốc độ hoặc không nhường đường khi điều khiển xe chạy từ trong ngõ, đường nhánh ra đường chính ", "100", "200", "");
            dt_All.Rows.Add("3", "Điều khiển xe chạy tốc độ thấp mà không đi bên phải phần đường xe chạy gây cản trở giao thông", "100", "200", "");
            dt_All.Rows.Add("4", "Điều khiển xe chạy quá tốc độ quy định từ 5 km/h đến dưới 10 km/h ", "100", "200", "");
            dt_All.Rows.Add("5", "Điều khiển xe chạy dưới  tốc độ tối thiểu trên những đoạn đường bộ có quy định tốc độ tối thiểu cho phép", "200", "400", "");
            dt_All.Rows.Add("6", "Điều khiển xe chạy quá tốc độ quy định từ 10 km/h đến 20 km/h ", "500", "1.000", "");
            dt_All.Rows.Add("7", "Điều khiển xe chạy quá tốc độ quy định trên 20 km/h", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("8", "Tụ tập để cổ vũ , kích động hành vi điều khiển xe chạy quá tốc độ quy định, lạng lách, đánh võng, đuổi nhau trên đường hoặc đua xe trái phép", "1.000", "2.000", "");
            dt_All.Rows.Add("9", "Đua xe mô tô , xe gắn máy, xe máy điện trái phép", "1.000", "2.000", "Tước quyền sử dụng giấy phép lái xe 4 tháng và tịch thu phương tiện");
            dt_All.Rows.Add("10", "Điều khiển xe thành nhóm từ 02 (hai) xe trở lên chạy quá tốc độ quy định", "5.000", "7.000", "");
            dt_All.Rows.Add("11", "Điều khiển xe thành nhóm từ 02 (hai) xe trở lên chạy quá tốc độ quy định mà gây tai nạn giao thông ", "", "", "Tước quyền sử dụng giấy phép lái xe 4 tháng");
            dt_All.Rows.Add("12", "Điều khiển xe thành nhóm từ 02 (hai) xe trở lên chạy quá tốc độ quy định mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ ", "10.000", "14.000", "");
            dt_All.Rows.Add("13", "Điều khiển xe trên đường mà trong máu hoặc hơi thở có nồng độ cồn vượt quá 50 miligram đến 80 miligram/100 mililít máu hoặc vượt quá 0.25 miligram đến 0.4 miligram/1 lít khí thở", "500", "1.000", "Tước quyền sử dụng giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("14", "Điều khiển xe trên đường mà trong máu hoặc hơi thở có nồng độ cồn vượt quá 50 miligram đến 80 miligram/100 mililít máu hoặc vượt quá 0.25 miligram đến 0.4 miligram/1 lít khí thở và gây tai nạn giao thông", "500", "1.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("15", "Không chấp hành yêu cầu kiểm tra về chất ma túy, nồng độ cồn của người kiểm soát giao thông hoặc người thi hành công vụ", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("16", "Điều khiển xe trên đường mà trong máu hoặc hơi thở có nồng độ cồn vượt quá 80 miligram/100 mililít máu hoặc vượt quá 0.4 miligram/1 lít khí thở", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("17", "Đối với người điều khiển xe trên đường mà trong cơ thể có chất ma túy", "2.000", "3.000", "Hoặc tước quyền sử dụng giấy phép lái xe 24 tháng");
            dt_All.Rows.Add("18", "Xe không có còi; đèn soi biển số; đèn báo hãm; gương chiếu hậu bên trái người điều khiển hoặc có nhưng không có tác dụng", "80", "100", "");
            dt_All.Rows.Add("19", "Xe gắn biển số không đúng quy định; biển số không rõ chữ; biển số bị bẻ cong, bị che lấp, bị hỏng", "80", "100", "");
            dt_All.Rows.Add("20", "Xe không có đèn tín hiệu hoặc có nhưng không có tác dụng", "80", "100", "");
            dt_All.Rows.Add("21", "Sử dụng còi không đúng quy chuẩn kĩ thuật cho từng loại xe", "100", "200", "Tịch thu còi");
            dt_All.Rows.Add("22", "Điều khiển xe không có bộ phận giảm thanh, giảm khói hoặc có nhưng không đảm bảo quy chuẩn môi trường về khí thải, tiếng ồn", "100", "200", "");
            dt_All.Rows.Add("23", "Điều khiển xe không có đèn chiếu sáng gần, xa hoặc có nhưng không có tác dụng , không đúng tiêu chuẩn thiết kế", "100", "200", "");
            dt_All.Rows.Add("24", "Điều khiển xe không có hệ thống hãm hoặc có nhưng không đảm bảo yêu cầu tiêu chuẩn kĩ thuật", "100", "200", "");
            dt_All.Rows.Add("25", "Điều khiển xe lắp đèn chiếu sáng  về phía sau xe", "100", "200", "");
            dt_All.Rows.Add("26", "Tự ý cắt, hàn, đục lại số khung, số máy", "800", "1.000", "Đối với tổ chức: phạt từ 1600 đến 2.000");
            dt_All.Rows.Add("27", "Tự ý thay đổi khung, máy, hình dáng, kích thước, đặc tính của xe", "800", "1.000", "Đối với tổ chức: phạt từ 1600 đến 2.000");
            dt_All.Rows.Add("28", "Tự ý thay đổi nhãn hiệu, màu sơn của xe không đúng với Giấy đăng kí xe", "100", "200", "Đối với tổ chức: phạt từ 200 đến 400 và phải khôi phục lại nhãn hiệu, màu sơn ghi trong Giấy đăng kí xe hoặc thực hiện đúng quy định về biển số, quy định về kẻ chữ trên thành xe và cửa xe");
            dt_All.Rows.Add("29", "Giao xe hoặc để cho người không đủ điều kiện theo quy định tại Khoản 1 điều 58 của Luật giao thông đường bộ điều khiển xe tham gia giao thông", "800", "1.000", "Đối với tổ chức: phạt từ 1600 đến 2.000");
            dt_All.Rows.Add("30", "Người điều khiển xe mô tô không mang theo Giấy phép lái xe", "80", "120", "");
            dt_All.Rows.Add("31", "Điều khiển xe không có Giấy đăng kí xe theo quy định", "300", "400", "");
            dt_All.Rows.Add("32", "Sử dụng Giấy đăng kí xe đã bị tẩy xóa; sử dụng Giấy đăng kí xe không đúng số khung, số máy của xe hoặc không do cơ quan có thẩm quyền cấp", "300", "400", "Tịch thu Giấy đăng kí xe, biển số không đúng quy định");
            dt_All.Rows.Add("33", "Điều khiển xe không gắn biển số (đối với loại xe có quy định phải gắn biển số); gắn biển số không đúng với biển số đăng kí trong Giấy đăng kí xe; biển số không do cơ quan có thẩm quyền cấp", "300", "400", "Tịch thu Giấy đăng kí xe, biển số không đúng quy định");
            dt_All.Rows.Add("34", "Điều khiển xe đăng kí tạm hoạt động quá phạm vi, thời hạn cho phép", "800", "1.000", "Tước quyền sử dụng Giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("35", "Điều khiển loại xe sản xuất, lắp ráp trái quy định tham gia giao thông", "800", "1.000", "Tịch thu phương tiện và tước quyền sử dụng Giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("36", "Người điều khiển xe mô tô, xe gắn máy, các loại xe tương tự xe mô tô và các loại xe tương tự xe gắn máy không có hoặc không mang theo Giấy chứng nhận bảo hiểm trách nhiệm dân sự của chủ xe cơ giới còn hiệu lực", "80", "120", "");
            dt_All.Rows.Add("37", "Người từ đủ 14 tuổi đến dưới 16 tuổi điều khiển xe mô tô, xe gắn máy (kể cả xe máy điện) và các loại xe tương tự xe mô tô hoặc điều khiển xe ô tô, máy kéo và các loại xe tương tự xe ô tô", "", "", "Phạt cảnh cáo");
            dt_All.Rows.Add("38", "Người từ đủ 16 tuổi đến dưới 18 tuổi điều khiển xe mô tô có dung tích xi lanh từ 50 cm3 trở lên", "400", "600", "");
            dt_All.Rows.Add("39", "Điều khiển xe mô tô không có Giấy phép lái xe hoặc sử dụng Giấy phép lái xe không do cơ quan thẩm quyền cấp, Giấy phép lái xe bị tẩy xóa, trừ các hành vi vi phạm quy định tại Điểm b Khoản 7 Điều 21", "800", "1200", "Tịch thu Giấy phép lái xe không do cơ quan có thẩm quyền cấp, Giấy phép lái xe bị tẩy xóa");
            dt_All.Rows.Add("40", "Điều khiển xe mô tô có dung tích xi lanh từ 175 cm3 trở lên có Giấy phép lái xe nhưng không phù hợp với loại xe đang điều khiển hoặc đã hết hạn sử dụng từ 6 tháng trở lên", "4.000", "6.000", "");
            dt_All.Rows.Add("41", "Điều khiển xe mô tô có dung tích xi lanh từ 175 cm3 trở lên không có Giấy phép lái xe hoặc sử dụng Giấy phép lái xe không do cơ quan có thẩm quyền cấp, Giấy phép lái xe bị tẩy xóa", "4.000", "6.000", "Tịch thu Giấy phép lái xe không do cơ quan có thẩm quyền cấp, Giấy phép lái xe bị tẩy xóa");
            dt_All.Rows.Add("42", "Không làm thủ tục đăng kí sang tên xe (để chuyển tên chủ xe trong Giấy đăng kí xe sang tên của mình) theo quy định khi mua, được cho, được tặng, được phân bổ, được điều chuyển, được thừa kế tài sản là xe mô tô, xe gắn máy, các loại xe tương tự xe mô tô", "100", "200", "Đối với tổ chức: phạt từ 200 đến 400");
            dt_All.Rows.Add("43", "Tẩy xóa, sửa chữa hoặc giả mạo hồ sơ đăng kí xe", "800", "1.000", "Đối với tổ chức: phạt từ 1600 đến 2.000 và bị tịch thu biển số, Giấy đăng kí xe (nếu đã được cấp lại), tịch thu hồ sơ, các loại giấy tờ, tài liệu giả mạo");
            dt_All.Rows.Add("44", "Khai báo không đúng sự thật hoặc sử dụng các loại giấy tờ, tài liệu giả để được cấp lại biển số, Giấy đăng kí xe", "800", "1.000", "Đối với tổ chức: phạt từ 1600 đến 2.000 và bị tịch thu biển số, Giấy đăng kí xe (nếu đã được cấp lại), tịch thu hồ sơ, các loại giấy tờ, tài liệu giả mạo");
            dt_All.Rows.Add("45", "Người điều khiển xe mô tô, xe gắn máy, các loại xe tương tự xe mô tô và các loại xe tương tự xe gắn máy không mang theo Giấy đăng kí xe", "80", "120", "");
            dt_All.Rows.Add("46", "Dừng xe, đỗ xe trong hầm đường bộ không đúng nơi quy định", "500", "1.000", "");
            dt_All.Rows.Add("47", "Dừng xe, đỗ xe trên phần đường xe chạy ở đoạn đường ngoài đô thị nơi có lề đường", "100", "200", "");
            dt_All.Rows.Add("48", "Dừng xe, đỗ xe trên phần đường xe chạy ở đoạn đường ngoài đô thị nơi có lề đường mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("49", "Dừng xe, đỗ xe ở lòng đường đô thị gây cản trở giao thông; tụ tập từ 3 (ba) xe trở lên ở lòng đường, trên cầu, trong hầm đường bộ; đỗ, để xe ở lòng đường đô thị, hè phố trái quy định của pháp luật", "100", "200", "");
            dt_All.Rows.Add("50", "Dừng xe, đỗ xe ở lòng đường đô thị gây cản trở giao thông; tụ tập từ 3 (ba) xe trở lên ở lòng đường, trên cầu, trong hầm đường bộ; đỗ, để xe ở lòng đường đô thị, hè phố trái quy định của pháp luật mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("51", "Dừng xe, đỗ xe trên đường xe điện, điểm dừng đón trả khách của xe buýt, trên cầu, nơi đường bộ giao nhau, trên phần đường dành cho người đi bộ qua đường; dừng xe nơi có biển \"Cấm dừng xe và đỗ xe\"; đỗ xe tại nơi có biển \"Cấm đỗ xe\" hoặc biển \"Cấm dừng xe và đỗ xe\"; không tuân thủ các quy định về dừng xe, đỗ xe tại nơi đường bộ giao nhau cùng mức với đường sắt; dừng xe, đỗ xe trong phạm vi an toàn của đường sắt, trừ hành vi vi phạm quy định tại Điểm b Khoản 3 Điều 48 Nghị định 171", "100", "200", "");
            dt_All.Rows.Add("52", "Dừng xe, đỗ xe trên đường xe điện, điểm dừng đón trả khách của xe buýt, trên cầu, nơi đường bộ giao nhau, trên phần đường dành cho người đi bộ qua đường; dừng xe nơi có biển \"Cấm dừng xe và đỗ xe\"; đỗ xe tại nơi có biển \"Cấm đỗ xe\" hoặc biển \"Cấm dừng xe và đỗ xe\"; không tuân thủ các quy định về dừng xe, đỗ xe tại nơi đường bộ giao nhau cùng mức với đường sắt; dừng xe, đỗ xe trong phạm vi an toàn của đường sắt, trừ hành vi vi phạm quy định tại Điểm b Khoản 3 Điều 48 Nghị định 172 mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("53", "Điều khiển xe mô tô, xe gắn máy (kể cả xe máy điện), các loại xe tương tự xe mô tô và các loại xe tương tự xe gắn máy dừng xe, đỗ xe trong phạm vi đường ngang, cầu chung", "100", "200", "");
            dt_All.Rows.Add("54", "Không có báo hiệu xin vượt trước khi vượt", "60", "80", "");
            dt_All.Rows.Add("55", "Vượt bên phải trong các trường hợp không được phép", "200", "400", "");
            dt_All.Rows.Add("56", "Vượt xe trong hầm đường bộ không đúng nơi quy định", "500", "1.000", "");
            dt_All.Rows.Add("57", "Vượt xe trái quy định gây tai nạn giao thông", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("58", "Quay đầu xe tại nơi cấm quay đầu xe", "80", "100", "");
            dt_All.Rows.Add("59", "Quay đầu xe tại nơi cấm quay đầu xe mà gây tai nạn giao thông ", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("60", "Chuyển hướng không giảm tốc độ hoặc không có tín hiệu báo hướng rẽ", "200", "400", "");
            dt_All.Rows.Add("61", "Quay đầu xe trong hầm đường bộ", "500", "1.000", "");
            dt_All.Rows.Add("62", "Chuyển hướng không nhường đường cho: các xe đi ngược chiều ; người đi bộ, xe lăn của người khuyết tật đang qua đường tại nơi không có vạch kẻ đường cho người đi bộ", "60", "80", "");
            dt_All.Rows.Add("63", "Chuyển hướng không nhường đường cho: các xe đi ngược chiều ; người đi bộ, xe lăn của người khuyết tật đang qua đường tại nơi không có vạch kẻ đường cho người đi bộ mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("64", "Chuyển hướng không nhường quyền đi trước cho: người đi bộ, xe lăn của người khuyết tật qua đường tại nơi có vạch kẻ đường cho người đi bộ; xe thô sơ đang đi trên phần đường dành cho xe thô sơ", "60", "80", "");
            dt_All.Rows.Add("65", "Chuyển hướng không nhường quyền đi trước cho: người đi bộ, xe lăn của người khuyết tật qua đường tại nơi có vạch kẻ đường cho người đi bộ; xe thô sơ đang đi trên phần đường dành cho xe thô sơ mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("66", "Xe được quyền ưu tiên khi làm nhiệm vụ không có tín hiệu còi, cờ, đèn theo đúng quy định", "80", "100", "");
            dt_All.Rows.Add("67", "Bấm còi, rú ga liên tục trong đô thị, khu đông dân cư, trừ các xe ưu tiên đang đi làm nhiệm vụ theo quy định", "100", "200", "");
            dt_All.Rows.Add("68", "Sử dụng đèn chiếu xa khi tránh xe đi ngược chiều", "60", "80", "");
            dt_All.Rows.Add("69", "Sử dụng đèn chiếu xa khi tránh xe đi ngược chiều mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("70", "Lùi xe mô tô ba bánh không quan sát hoặc không có tín hiệu báo trước", "60", "80", "");
            dt_All.Rows.Add("71", "Lùi xe mô tô ba bánh không quan sát hoặc không có tín hiệu báo trước mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("72", "Bấm còi trong thời gian từ 22 giờ ngày hôm trước đến 5 giờ ngày hôm sau, sử dụng đèn chiếu xa trong khu đô thị, khu đông dân cư, trừ các xe ưu tiên đang đi làm nhiệm vụ theo quy định", "80", "100", "");
            dt_All.Rows.Add("73", "Không sử dụng đèn chiếu sáng khi trời tối hoặc khi sương mù, thời tiết xấu hạn chế tầm nhìn", "80", "100", "");
            dt_All.Rows.Add("74", "Không sử dụng đèn chiếu sáng khi trời tối hoặc khi sương mù, thời tiết xấu hạn chế tầm nhìn mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("75", "Không chấp hành hiệu lệnh của đèn tín hiệu giao thông trừ hành vi vi phạm tại Điểm c Khoản 4 Điều 6", "100", "200", "");
            dt_All.Rows.Add("76", "Không chấp hành hiệu lệnh của đèn tín hiệu giao thông trừ hành vi vi phạm tại Điểm c Khoản 4 Điều 6 mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("77", "Xe không được quyền ưu tiên sử dụng tín hiệu còi, cờ, đèn của xe ưu tiên", "100", "200", "Tịch thu còi, cờ, đèn sử dụng trái quy định");
            dt_All.Rows.Add("78", "Xe không được quyền ưu tiên sử dụng tín hiệu còi, cờ, đèn của xe ưu tiên mà gây ra tai nạn giao thông", "", "", "Tịch thu còi, cờ, đèn sử dụng trái quy định và bị tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("79", "Khi tín hiệu đèn giao thông đã chuyển sang màu đỏ nhưng không dừng lại trước vạch dừng mà vẫn tiếp tục đi, trừ trường hợp đã đi quá vạch dừng trước khi tín hiệu đèn giao thông chuyển sang màu vàng", "200", "400", "Tước quyền sử dụng giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("80", "Khi tín hiệu đèn giao thông đã chuyển sang màu đỏ nhưng không dừng lại trước vạch dừng mà vẫn tiếp tục đi, trừ trường hợp đã đi quá vạch dừng trước khi tín hiệu đèn giao thông chuyển sang màu vàng; trong trường hợp gây tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("81", "Chạy trong hầm đường bộ không sử dụng đèn chiếu sáng gần", "500", "1.000", "");
            dt_All.Rows.Add("82", "Chạy trong hầm đường bộ không sử dụng đèn chiếu sáng gần mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("83", "Người điều khiển xe mô tô, xe gắn máy (kể cả xe máy điện), các loại xe tương tự xe mô tô và các loại xe tương tự xe gắn máy không chấp hành chỉ dẫn hiệu lệnh của biển báo hiệu, vạch kẻ đường khi đi qua đường ngang, cầu chung", "100", "200", "");
            dt_All.Rows.Add("84", "Người điều khiển xe mô tô, xe gắn máy (kể cả xe máy điện), các loại xe tương tự xe mô tô và các loại xe tương tự xe gắn máy vượt rào chắn đường ngang, cầu chung khi đèn đỏ đã bật sáng; không chấp hành hiệu lệnh, chỉ dẫn của nhân viên gác đường ngang, cầu chung khi đi qua đường ngang, cầu chung", "200", "400", "");
            dt_All.Rows.Add("85", "Không chấp hành hiệu lệnh, chỉ dẫn của biển báo hiệu, vạch kẻ đường, trừ các hành vi vi phạm quy định tại Điểm a, Điểm đ, Điểm h Khoản 2; Điểm c, Điểm đ, Điểm h, Điểm o Khoản 3; Điểm c, Điểm d, Điểm e, Điểm g, Điểm i Khoản 4; Điểm a, Điểm c, Điểm d Khoản 5; Điểm đ Khoản 6; Điểm d Khoản 7 Điều 1", "60", "80", "");
            dt_All.Rows.Add("86", "Không chấp hành hiệu lệnh, chỉ dẫn của biển báo hiệu, vạch kẻ đường, trừ các hành vi vi phạm quy định tại Điểm a, Điểm đ, Điểm h Khoản 2; Điểm c, Điểm đ, Điểm h, Điểm o Khoản 3; Điểm c, Điểm d, Điểm e, Điểm g, Điểm i Khoản 4; Điểm a, Điểm c, Điểm d Khoản 5; Điểm đ Khoản 6; Điểm d Khoản 7 Điều 1 mà gây ra tai nạn giao thông ", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("87", "Không chấp hành hiệu lệnh, hướng dẫn của người điều khiển giao thông hoặc người kiểm soát giao thông", "200", "400", "Tước quyền sử dụng giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("88", "Không chấp hành hiệu lệnh, hướng dẫn của người điều khiển giao thông hoặc người kiểm soát giao thông mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("89", "Không nhường đường khi điều khiển xe chạy từ trong ngõ, đường nhánh ra đường chính", "100", "200", "");
            dt_All.Rows.Add("90", "Không tuân thủ các quy định về nhường đường tại nơi đường giao nhau, trừ các hành vi vi phạm quy định tại các Điểm d Khoản 2, Điểm b Khoản 3 Điều 6", "60", "80", "");
            dt_All.Rows.Add("91", "Không nhường đường cho xe xin vượt khi có đủ điều kiện an toàn; không nhường đường cho xe đi trên đường ưu tiên, đường chính từ bất kỳ hướng nào tới tại nơi đường giao nhau", "80", "100", "");
            dt_All.Rows.Add("92", "Không nhường đường cho xe xin vượt khi có đủ điều kiện an toàn; không nhường đường cho xe đi trên đường ưu tiên, đường chính từ bất kỳ hướng nào tới tại nơi đường giao nhau mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("93", "Tránh xe không đúng quy định; không nhường đường cho xe đi ngược chiều theo quy định tại nơi đường hẹp, đường dốc, nơi có chướng ngại vật.", "80", "100", "");
            dt_All.Rows.Add("94", "Tránh xe không đúng quy định; không nhường đường cho xe đi ngược chiều theo quy định tại nơi đường hẹp, đường dốc, nơi có chướng ngại vật mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("95", "Không nhường đường hoặc gây cản trở xe được quyền ưu tiên đang phát tín hiệu ưu tiên đi làm nhiệm vụ", "500", "1.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("96", "Chuyển làn đường không đúng nơi được phép hoặc không có tín hiệu báo trước", "80", "100", "");
            dt_All.Rows.Add("97", "Chuyển làn đường trái quy định gây tai nạn giao thông", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("98", "Điều khiển xe lạng lách hoặc đánh võng trên đường bộ trong, ngoài đô thị", "5.000", "7.000", "");
            dt_All.Rows.Add("99", "Điều khiển xe lạng lách hoặc đánh võng trên đường bộ trong, ngoài đô thị mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ", "10.000", "14.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("100", "Điều khiển xe lạng lách hoặc đánh võng trên đường bộ trong, ngoài đô thị mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ và tái phạm, vi phạm nhiều lần", "", "", "Tước quyền sử dụng giấy phép lái xe 4 tháng và tịch thu phương tiện");
            dt_All.Rows.Add("101", "Điều khiển xe chạy bằng một bánh đối với xe hai bánh, chạy bằng hai bánh đối với xe ba bánh", "5.000", "7.000", "");
            dt_All.Rows.Add("102", "Điều khiển xe chạy bằng một bánh đối với xe hai bánh, chạy bằng hai bánh đối với xe ba bánh mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ", "10.000", "14.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("103", "Điều khiển xe chạy bằng một bánh đối với xe hai bánh, chạy bằng hai bánh đối với xe ba bánh mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ và tái phạm, vi phạm nhiều lần", "", "", "Tước quyền sử dụng giấy phép lái xe 4 tháng và tịch thu phương tiện");
            dt_All.Rows.Add("104", "Người ngồi phía sau vòng tay qua người ngồi trước để điều khiển xe, trừ trường hợp chở trẻ em ngồi phía trước", "100", "200", "");
            dt_All.Rows.Add("105", "Điều khiển xe thành đoàn gây cản trở giao thông, trừ trường hợp được cơ quan có thẩm quyền cấp phép", "200", "400", "");
            dt_All.Rows.Add("106", "Sử dụng chân chống hoặc vật khác quệt xuống đường khi xe đang chạy", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("107", "Điều khiển xe chạy dàn hàng ngang từ 03 (ba) xe trở lên", "80", "100", "");
            dt_All.Rows.Add("108", "Điều khiển xe chạy dàn hàng ngang từ 03 (ba) xe trở lên mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("109", "Người đang điều khiển xe sử dụng ô, điện thoại di động, thiết bị âm thanh, trừ thiết bị trợ thính; người ngồi trên xe sử dụng ô", "60", "80", "");
            dt_All.Rows.Add("110", "Người đang điều khiển xe sử dụng ô, điện thoại di động, thiết bị âm thanh, trừ thiết bị trợ thính; người ngồi trên xe sử dụng ô mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("111", "Không giữ khoảng cách an toàn để xảy ra va chạm với xe chạy liền trước hoặc không giữ khoảng cách theo quy định của biển báo hiệu “Cự ly tối thiểu giữa hai xe”", "60", "80", "");
            dt_All.Rows.Add("112", "Không giữ khoảng cách an toàn để xảy ra va chạm với xe chạy liền trước hoặc không giữ khoảng cách theo quy định của biển báo hiệu “Cự ly tối thiểu giữa hai xe” mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("113", "Người điều khiển, người ngồi trên xe không đội “mũ bảo hiểm cho người đi mô tô, xe máy” hoặc đội “mũ bảo hiểm cho người đi mô tô, xe máy” không cài quai đúng quy cách khi tham gia giao thông trên đường bộ", "100", "200", "");
            dt_All.Rows.Add("114", "Chở người ngồi trên xe không đội “mũ bảo hiểm cho người đi mô tô, xe máy” hoặc đội “mũ bảo hiểm cho người đi mô tô, xe máy” không cài quai đúng quy cách, trừ trường hợp chở người bệnh đi cấp cứu, trẻ em dưới 06 tuổi, áp giải người có hành vi vi phạm pháp luật", "100", "200", "");
            dt_All.Rows.Add("115", "Điều khiển xe có liên quan trực tiếp đến vụ tai nạn giao thông mà không dừng lại, không giữ nguyên hiện trường, không tham gia cấp cứu người bị nạn, trừ hành vi vi phạm quy định tại Điểm d Khoản 6 Điều 6", "100", "200", "");
            dt_All.Rows.Add("116", "Điều khiển xe đi vào đường cao tốc, trừ xe phục vụ việc quản lý, bảo trì đường cao tốc", "200", "400", "");
            dt_All.Rows.Add("117", "Điều khiển xe đi vào đường cao tốc, trừ xe phục vụ việc quản lý, bảo trì đường cao tốc mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("118", "Điều khiển xe không đi bên phải theo chiều đi của mình; đi không đúng phần đường, làn đường quy định hoặc điều khiển xe đi trên hè phố", "200", "400", "");
            dt_All.Rows.Add("119", "Điều khiển xe không đi bên phải theo chiều đi của mình; đi không đúng phần đường, làn đường quy định hoặc điều khiển xe đi trên hè phố mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("120", "Đi vào đường cấm, khu vực cấm; đi ngược chiều của đường một chiều, đường có biển “Cấm đi ngược chiều”, trừ trường hợp xe ưu tiên đang đi làm nhiệm vụ khẩn cấp theo quy định", "200", "400", "Tước quyền sử dụng giấy phép lái xe 1 tháng");
            dt_All.Rows.Add("121", "Đi vào đường cấm, khu vực cấm; đi ngược chiều của đường một chiều, đường có biển “Cấm đi ngược chiều”, trừ trường hợp xe ưu tiên đang đi làm nhiệm vụ khẩn cấp theo quy định; mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("122", "Người điều khiển xe hoặc người ngồi trên xe bám, kéo, đẩy xe khác, vật khác, dẫn dắt súc vật, mang vác vật cồng kềnh; người ngồi trên xe đứng trên yên, giá đèo hàng hoặc ngồi trên tay lái; xếp hàng hóa trên xe vượt quá giới hạn quy định; điều khiển xe kéo theo xe khác, vật khác", "200", "400", "");
            dt_All.Rows.Add("123", "Người điều khiển xe hoặc người ngồi trên xe bám, kéo, đẩy xe khác, vật khác, dẫn dắt súc vật, mang vác vật cồng kềnh; người ngồi trên xe đứng trên yên, giá đèo hàng hoặc ngồi trên tay lái; xếp hàng hóa trên xe vượt quá giới hạn quy định; điều khiển xe kéo theo xe khác, vật khác mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("124", "Gây tai nạn giao thông không dừng lại, không giữ nguyên hiện trường, bỏ trốn không đến trình báo với cơ quan có thẩm quyền, không tham gia cấp cứu người bị nạn", "2.000", "3.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("125", "Buông cả hai tay khi đang điều khiển xe; dùng chân điều khiển xe; ngồi về một bên điều khiển xe; nằm trên yên xe điều khiển xe; thay người điều khiển khi xe đang chạy; quay người về phía sau để điều khiển xe hoặc bịt mắt điều khiển xe", "5.000", "7.000", "");
            dt_All.Rows.Add("126", "Buông cả hai tay khi đang điều khiển xe; dùng chân điều khiển xe; ngồi về một bên điều khiển xe; nằm trên yên xe điều khiển xe; thay người điều khiển khi xe đang chạy; quay người về phía sau để điều khiển xe hoặc bịt mắt điều khiển xe mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ", "10.000", "14.000", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("127", "Buông cả hai tay khi đang điều khiển xe; dùng chân điều khiển xe; ngồi về một bên điều khiển xe; nằm trên yên xe điều khiển xe; thay người điều khiển khi xe đang chạy; quay người về phía sau để điều khiển xe hoặc bịt mắt điều khiển xe mà gây tai nạn giao thông hoặc không chấp hành hiệu lệnh dừng xe của người thi hành công vụ và tái phạm, vi phạm nhiều lần", "", "", "Tước quyền sử dụng giấy phép lái xe 4 tháng và tịch thu phương tiện");
            dt_All.Rows.Add("128", "Chở theo 02 (hai) người trên xe, trừ trường hợp chở người bệnh đi cấp cứu, trẻ em dưới 14 tuổi, áp giải người có hành vi vi phạm pháp luật", "100", "200", "");
            dt_All.Rows.Add("129", "Chở theo từ 03 (ba) người trở lên trên xe", "200", "400", "");
            dt_All.Rows.Add("130", "Chở theo từ 03 (ba) người trở lên trên xe mà gây ra tai nạn giao thông", "", "", "Tước quyền sử dụng giấy phép lái xe 2 tháng");
            dt_All.Rows.Add("131", "Chở hàng vượt trọng tải thiết kế được ghi trong Giấy đăng ký xe đối với loại xe có quy định về trọng tải thiết kế", "200", "400", "");
            InitializeComponent();

        }


        private void label1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            uc_list[] songlists = new uc_list[dt_All.Rows.Count * dt_All.Rows.Count];
            var i = 0;

            if(textBox1.Text == "không sử dụng đèn chiếu sáng khi trời tối")
            {
                i = 0;
                for (int index = 73; index <= 74; index++)
                { 
                    songlists[i] = new uc_list();

                    songlists[i].label1.Text = dt_All.Rows[index]["Noidung"].ToString();
                    songlists[i].lab_id.Text = index.ToString();

                    flowLayoutPanel1.Controls.Add(songlists[i]);

                    songlists[i].Click += new System.EventHandler(this.Usercontrol_Click);
                }
            }
            StringComparison stringComparison;
            EnumerableRowCollection<DataRow> matches;

            stringComparison = StringComparison.Ordinal; //bỏ qua viet HOA

            //matches = dt_All.AsEnumerable().Where(row => row.Field<string>("Noidung").IndexOf(textBox1.Text.ToString(), stringComparison) != -1);
            matches = dt_All.AsEnumerable().Where(r => r.Field<string>("Noidung").Contains(textBox1.Text));

            i = 0;

            foreach (var match in matches)     
            {
                int index = dt_All.Rows.IndexOf(match);


                songlists[i] = new uc_list();

                songlists[i].label1.Text = dt_All.Rows[index]["Noidung"].ToString();
                songlists[i].lab_id.Text = index.ToString();

                flowLayoutPanel1.Controls.Add(songlists[i]);

                songlists[i].Click += new System.EventHandler(this.Usercontrol_Click);
                i++;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            uc_list[] songlists = new uc_list[dt_All.Rows.Count];

            for (int i = 0; i < dt_All.Rows.Count; i++)
            {
                songlists[i] = new uc_list();

                songlists[i].label1.Text = dt_All.Rows[i]["Noidung"].ToString();
                songlists[i].lab_id.Text = i.ToString();


                flowLayoutPanel1.Controls.Add(songlists[i]);
                songlists[i].Click += new System.EventHandler(this.Usercontrol_Click);

            }
        }

        void Usercontrol_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            uc_list obj = (uc_list)sender;

            int index = int.Parse(obj.lab_id.Text);
            dtl_name.Text = dt_All.Rows[index]["Noidung"].ToString();
            dtl_money.Text = dt_All.Rows[index]["TienMin"].ToString() + ".000 - " + dt_All.Rows[index]["TienMax"].ToString() + ".000";
            dtl_extra.Text = dt_All.Rows[index]["Bosung"].ToString();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               label1_Click(sender, e);
            }
        }
    }
}

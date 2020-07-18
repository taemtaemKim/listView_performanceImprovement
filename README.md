# listView_performanceImprovement
조건, 실험방법

- 10000개 돌리기
- 내노트북



| 제목     | rawData                                                      |
| -------- | ------------------------------------------------------------ |
| 방법     |                                                              |
| log      | ###############dataLoadFromSVC.Start : 0ms<br/>###############dataLoad.Start : 18ms<br/>###############dataLoad.End : 9,819ms<br/>###############dataLoadFromSVC.End : 9,819ms |
| 소요시간 | **약 9.8초**                                                 |



| 제목     | listveiw에 삽입 없이 돌리기                                  |
| -------- | ------------------------------------------------------------ |
| 방법     | listView.Items.Add(item); 삭제                               |
| log      | ###############dataLoadFromSVC.Start : 0ms<br/>###############dataLoad.Start : 17ms<br/>###############dataLoad.End : 56ms<br/>###############dataLoadFromSVC.End : 56ms |
| 소요시간 | **약 0초**                                                   |



| 제목     | listView에 요소하기 전에 update미리 선언                     |
| -------- | ------------------------------------------------------------ |
| 방법     | while문 앞뒤로<br />listView.BeginUpdate();<br />listView.EndUpdate();<br />삽입 |
| log      | ###############dataLoadFromSVC.Start : 0ms<br/>###############dataLoad.Start : 17ms<br/>###############dataLoad.End : 2,965ms<br/>###############dataLoadFromSVC.End : 2,965ms |
| 소요시간 | **약 2.9초**                                                 |



| 제목     | ListViewItems를 우선 만들고, 나중에 add하기                  |
| -------- | ------------------------------------------------------------ |
| 방법     | myLog("dataLoad.Start");<br/>            // data 추가<br/>            int count = 0;<br/><br/>            List<ListViewItem> items = new List<ListViewItem>();<br/><br/>            //items 채우기<br/>            while (!reader.EndOfStream)<br/>            {<br/>                String line = reader.ReadLine();<br/>                String[] values = line.Split(',');<br/>                var item = new ListViewItem(values[0]);<br/><br/>                foreach (String val in values)<br/>                {<br/>                    item.SubItems.Add(val);<br/>                }<br/><br/>                items.Add(item);<br/>            }<br/>            myLog("dataLoad.End");<br/><br/>            myLog("listView.Items.Add(item).Start");<br/>            //items하나씩 listView 넣기<br/>            listView.BeginUpdate();<br/>            foreach(ListViewItem item in items)<br/>                listView.Items.Add(item);<br/>            listView.EndUpdate();<br/>            myLog("listView.Items.Add(item).End"); |
| log      | ###############dataLoadFromSVC.Start : 0ms<br/>###############dataLoad.Start : 18ms<br/>###############dataLoad.End : 437ms<br/>###############listView.Items.Add(item).Start : 437ms<br/>###############listView.Items.Add(item).End : 13,230ms<br/>###############dataLoadFromSVC.End : 13,230ms |
| 소요시간 | **약 13초**                                                  |
| 특이사항 | 왜 시간이 더 늘어나지...?                                    |

- 추가
  - foreach(ListViewItem item in items) 자체가 시간이 많이 걸리는 줄listView.Items.Add(item); 빼고 돌리니깐 시간줄어듬. **(0초)**
    - ###############dataLoadFromSVC.Start : 0ms
      ###############dataLoad.Start : 18ms
      ###############dataLoad.End : 465ms
      ###############listView.Items.Add(item).Start : 465ms
      ###############listView.Items.Add(item).End : 466ms
      ###############dataLoadFromSVC.End : 466ms
  - listView.BeginUpdate() 이게 작동 안 한 줄 알았더니 그건 또 아님 **(32초)**
    - ###############dataLoadFromSVC.Start : 1ms
      ###############dataLoad.Start : 19ms
      ###############dataLoad.End : 449ms
      ###############listView.Items.Add(item).Start : 449ms
      ###############listView.Items.Add(item).End : 32,514ms
      ###############dataLoadFromSVC.End : 32,514ms
  - foreach를 for문으로 바꾸면 더 빨라진다고 함. **(12.5초)**
    - for (int i = 0; i < items.Count; i++)
          listView.Items.Add(items[i]);
      listView.EndUpdate();
    - ###############dataLoadFromSVC.Start : 0ms
      ###############dataLoad.Start : 17ms
      ###############dataLoad.End : 459ms
      ###############listView.Items.Add(item).Start : 459ms
      ###############listView.Items.Add(item).End : 12,563ms
      ###############dataLoadFromSVC.End : 12,563ms


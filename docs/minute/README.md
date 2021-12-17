# 회의록
프로젝트 진행 과정을 담은 회의록입니다.

## 회의 진행 노트(사전준비) 21.07.13 ~ 15 
국토지리정보원 데이터 신청(반려) & Requirement Analysis, Use Case, Domain Model, Class Diagram, Sequence Diagram(목표 설정)

## 회의 진행 노트(1회) 21.07.16 
기술개발팀 : 역할분배
건학 – 유니티 & 태양 벡터 계산 방법 공부
상엽 – 건물의 데이터 수집 / 제공에 대한 공부, 일조량 알고리즘 개발

기획디자인팀 : 플로우 차트, 와이어 프레임, 기능명세서 취합
7월 : 관련 지식 공부 ( 유니티, 건물 데이터, 태양 위치 계산 ) 및 일조량 알고리즘 (light detection) 구현
8월 : fbx 모델 import 기능 및 건물 데이터 열람 기능 개발, 태양 벡터 계산 방법에 대한 공부
9월 : UX/UI 구축 및 시뮬레이션, 자체 디자인 기능 및 태양 벡터 계산 알고리즘 구현
10월, 11월 : 디버깅, 테스트, 디자인 수정 등

일조량 알고리즘 활용 방안
(1,3) 위치에 어느 특정 시간에 55%만큼의 빛이 들어온다.
1시간마다 일조량의 평균치를 계산. (예 : 1시~2시 사이에 40%만큼 일조량 발생)
24시간마다 일조량의 평균치를 계산.
일조량의 수치에 따라 색깔로 구분.
층별 구분 -> 3D 모델링 과정에서 건물을 따로 선택하는 것이 불가능함. 따라서 건물의 모델링 정보를 알 수 없어 층별로 일조량 계산을 하는 것이 사실상 불가능할 것 같다는 생각.

## 회의 진행 노트(2회) 21.07.23 
#기술개발팀
Light의 rotation 계산 – 알고 보니 방위각 & 고도였다!
-> 특정 날짜 & 시간 & 위치에서의 방위각과 고도 계산 (건학 – 일주일 안에 계산 가능 할 듯)
어느 지역? 얼마나 많은 건물? -> 일단 최대치까지 해본 뒤에 결정
(원기둥에) 일정한 간격으로 점을 찍는 게 나을 것 같다
-> 직육면체가 더 나을 듯.

건물 데이터 수집 및 제공 – 건물의 수가 많지 않으므로 api를 사용하기 보다는 직접 정보를 얻고 코드 내에 저장한 뒤에 불러오는 방식 사용?

#기획디자인팀
기획디자인팀 회의록
일시 : 2021년 7월 23일 22:15~
참가자 : 백선재, 김지수, 송치원

오늘 할 것 : 기능명세서 마무리, 이거 끝나면 할 거 생각
	     월요일 회의 후 잠깐 얘기하면 수정

결과 : 기능명세서 완성

개발팀과 논의할 것 :
1.	업데이트 어떻게 할 지? -> 카카오 지하철처럼 서버와 비교 후 추가 데이터 패치?
2.	Api 사용할 지? -> 상엽님과 얘기
3.	2D 지도 가능?
4.	로그인

앞으로 해야할 것 :
1.	월요일에 피드백 받아서 수정
2.	수정 받은 것 기반으로 디자인 가이드 제작

치원 해야할 것
-	월요일에 멘토님에게 컴퓨터 부속품 구매 가능한 지 -> 계산 및 그래픽 연산에 문제가…

## 회의 진행 노트(3회) 21.07.26 
#기술개발팀
태양의 방위각과 고도, directional light의 rotation은 같은 것인가?
-> 일단 데이터 테스트 해보고 판단하기로 함.
오브젝트의 y scale을 0으로 하면 2D가 가능할 지도…?
-> 8월 2일 전체 회의 때 다시 한번 논의
Light Detection 알고리즘의 방향성
-> 지금 방식에서 n을 높인 뒤에 필터링을 거치는 것은 좋은 것 같다. 다만 나중에 건물 데이터에 직접 적용한 뒤에 결정하는 것으로.
건물 데이터 엑셀로 옮기기
-> 8월 2일 전까지 시도해보기
fbx 모델 import, 간편 디자인 기능.
-> 관련 정보 탐색.

앞으로 해야 할 일
건학 – 방위각 & 고도 계산해서 데이터 제공
상엽 – 건물 데이터 엑셀로 옮기기, 모델 제공 관련 정보 탐색

#기획디자인팀
1.	일시 : 2021년 7월 27일 23:30 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의내용
a.	디자인 가이드 업무 분담
1)	백선재 – 지도
2)	김지수 – 메뉴, 검색
3)	송치원 – 간편 모델링
-	할 수 있는 만큼 최대한 디자인가이드+레퍼런스 해오기

b.	시뮬레이션 지역 선정
1)	상엽님 집 주변으로 설정
-	개발자가 익숙한 동네라서, 신뢰도를 눈으로 어느정도 확인 가능.

#21.08.01 기획디자인팀 자체회의
1.	일시 : 2021년 8월 1일 22:15 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의 안건 
 A.	작업물 공유 및 설명
  1)	선재 
   a)	시간은 스크롤 -> 오른쪽 그림처럼, 시간 입력은 되면 스크롤, 힘들면 입력
      	나중에 디자인을 해서 톤앤매너가 대충 정해지면 그때 결정하는 걸로
   b)	건물 겉에 층 수를 텍스쳐로 붙이기 -> 가능한가? -> 물어보기!
   c)	층의 일부만 해가 비칠 경우, 일조시간 계산 어떻게 할거야?
   d)	구글 어스 프로 참고 – 건물 숨기기 -> 순서도나 디자인할 때 우리가 참고
   e)	건축물 대장 유료 -> 어떡할래? -> api는 공짜
   f)	연구비로 어플 구매해서 보는 것도 나쁘지 않음 -> 내일 물어보겠습니당
  2)	지수 – 논의할 것 없음
  3)	치원 – 논의할 것 없음

 B.	플로우차트 만들지?
  1)	다음 회의까지 만들기 – 내일 회의 끝나고 날짜 결정

 C.	일조시간 계산 어떻게할지
  1) 다시 고민

 D.	월요일(내일) 논의할 것 혹은 개발팀에게 물어볼 것
   1)	층 수 텍스쳐 물어보기
   2)	일조시간 계산양? -> 논의필요!! 5명 모두 하나씩 가져오기 ㅠ
   3)	기능명세서에 있는 기능 구현 언제부터 시작인지? 최종 기능명세서 전달 관련하여 
궁금

  E.	앞으로 계획
   1)	순서도나 디자인 가이드 만들면서 나오는 새로운 기능들 한번에 종합해서 기능명세서에 입력할 것
   2)	내일 멘토님께 연구비 사용 문의 
    a)	선재님 보내주시는 것들
    b)	컴퓨터 부품
   3)	치원 – 순서도 보충 및 향후 계획 설정
      지수 – 순서도 완성
      선재 – 순서도 완성
   4)	순서도 끝나면 디자인가이드 완성하고 디자인 작업 시작. 디귿자 건물

## 회의 진행 노트(4회) 21.08.02 
1.	일시 : 2021년 8월 2일 22:00 ~
2.	참여자 : 김지수, 백선재, 김건학, 박상엽, 송치원
3.	회의내용
A.	기술개발팀 진행 현황 및 계획 설명
1)	태양의 방위각, 고도 계산 및 데이터 확인 완료.
2)	2D는 그냥 y = 0 로 만들어서, 야매스럽지만 활용방법이 있을지도
3)	데이터 계산 방법 (필터링) 필요
4)	데이터가 다 있지 않아서 좌표로 하는 건 힘들지도..? 직접해야할걸 ㅠ
5)	obj도 가능 import 가능. Stl, 륱는 유료
6)	상세디자인 구현 불가
논의할 것 :
7)	지역 & 건물 범위 지정 필요 – 상징적인 지역? (시청, 광화문 등) 
왜냐하면, 구분이 잘 안감 ㅠ
8)	샘플모델 얼마나? -> 건학, 치원 천천히 정하는 걸로
9)	구현 언제 시작? -> 지역이 정해지면 프로젝트 만들어서 지금까지 해왔던 것 적용
	기획팀 시간에 설명
10)	층수따라 일조량 확인 어떻게 할건지?
구현할 것 :
11)	마우스 클릭을 감지해서 좌표를 구하고 그에 따라 오브젝트를 선택할 수 있게 하는 기능, 건물 정보 검색이나 클릭으로 인해 오브젝트가 선택되었을 때 카메라 뷰를 자연스럽게 이동시키는 기능 등등.. 이와 같은 것은 기능명세서가 최종적으로 결정되면 이후에 자세히 결정할 수 있음.

B.	기획지다인팀 진행 현황 및 계획 설명
1)	순서도 – 생각 필요
2)	층 수 텍스쳐 on/off 면 좋을 듯
3)	레퍼런스 어플 – 치원 내일 문의, 계정이랑 다중접속 문제? 새로 계정파서 그걸로 결제하고 그 이후는 그때 가서 생각;;;
4)	황도 불가
5)	시간 스크롤 구현 가능 – 디자인
6)	시각, 시간, 임의설정 구현 가능
계획
1)	다음 주 까지 순서도 완성, 토대로 기능명세서 작성해서 전달
2)	그 후, 디자인 시작
C.	일조량(일조시간) 계산 방법 관련 논의
-	다음 회의까지 각자 1개씩 고안해오기
D.	다음 회의 날짜 선정
-	2021년 8월 11일 수요일 22:00 
E.	기타 논의
-	없음

## 기획디자인팀 자체 회의
1.	일시 : 2021년 8월 10일 22:00 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의 내용
A.	순서도 설명

B.	구체적 목표 수립 (8, 9, 10, 11월 목표)
8월 – 순서도 -> 기능명세서
내일 알고리즘 -> 순서도 완성 -> 기능명세서 (순식간에) 완성 / 17일(가정) – 내일 여쭤보고 약수 (약간 수정이란 뜻 ;;)
디자인 가이드 / 18일
9월 – 디자인 완성 or 디자인 외주 끝
10월 - 
11월 - 

C.	목표에 따른 다음 주 목표 설정
17일까지 – 순서도 및 기능명세서 완성 
18일까지 – 디자인가이드 완성
D.	개발팀 논의할 것
디자인 외주 물어봐야할 듯
알고리즘 합의 (당연)

## 회의 진행 노트(5회) 21.08.11 
1.	일시 : 2021년 8월 11일 22:00 ~
2.	참여자 : 백선재, 김지수, 김건학, 박상엽, 송치원
3.	회의내용
A.	팀 별 진행상황
-	기획팀 : 일조량에 순서도 막혀서 오늘 결정나면 빠르게 완성
-	개발팀 : 선택한 오브젝트로 카메라 이동하는 것 구현
노가다 하는법
a)	층 당 미터?
b)	분류해서 통일?
c)	높이 없는 건 없애고 지역 수를 늘리자
c 안 한 다음 괜찮으면 그대로 진행
안괜찮으면 노가다 (제발 아니길)

B.	일조량 계산법 공유
a)	자체의 일조량 -> 필요 없다는 가정
층 수 선택 -> 이 안에서 max/min 보여주고, 평균 나타내고
디테일하게 들어가면 -> 사용자가 collider를 선택할 수 있게
b)	일조권 T/F

C.	디자인 외주?
돌고돌아 CDIC 결과보고

D.	(찐) 목표설정
디자인 – 개강주까지 외주넣는걸로 (예정)

E.	다음 회의날짜
8월 18일 (수)

# 기술개발팀 자체회의록(21.08.14)
2021.08.14 기술개발팀 회의록
1. 회의 목적
- 논의 사항 전달
- CDIC 탈락 이후, 디자인 외주에 관하여
- 앞으로의 구체적 계획 수립
2. 회의 내용
1) 논의 사항
MultiPolygon type의 데이터가 list 안에 list가 들어있는 형식으로 저장되어 있어서 Poser Query에서 값을 추출하면 error가 발생함. (해결!!!!!!!) MultiPolygon 좌표 값들을 사용할 때 그냥 맨 처음 좌표 값 찾아서 건물의 좌표라고 생각해도 괜찮을지 논의.
건물의 색을 변경하는 기능 관련 – 큐브나 구 대신 평면을 추가하는 것은 불가능. 건물의 표면 정보를 분석하는 알고리즘도 생각은 해봤으나 너무 비효율적이라 현실성이 떨어짐. Projector라고 Object의 material을 일부만 변경하는 기능이 있는 것 같아서 추가로 찾아보고 시도할 예정.
사용자가 원하는 만큼 영역을 선택한 뒤 일조 데이터를 제공하는 기능 관련 – 구현이 가능할까? 싶은 생각이 들었음. 사실 이게 제일 중요한 기능 같아서 어떻게 구현할지 생각해봐야함. 지금 생각하고 있는 방법은 사용자가 건물의 어느 특정 위치를 클릭하면 클릭한 위치에서 가장 가까운 hit point가 선택되고, 그 위치를 중심으로 반경 몇cm (예시) 이내의 point 들만 선택해서 정보 제공하는 방식.
-> 드래그나 ctrl 누르고 다중 선택도 좋을 듯.
언어 설정? (English or 한국어, 엑셀 연동 찾아보면서 생각난 부분인데, 보통 UI의 text 같은 것들을 excel을 사용해서 언어 별로 구분해 놓고 사용함) – 사실 영어를 사용할 필요가 있을까 싶기는 함.
45달러 유료 에셋 사용할 것인가? – 질문 예정
전체 회의 필요 내용 – BGM, Effect?
2) 디자인 외주
개발팀이 깊게 생각할 필요는 없다. 개발팀 생각은 반반.
3) 구체적 계획
8월 말 - api 데이터와 프로젝트 연동해서 건물 클릭하면 정보를 불러오는 기능 & 일조 데이터 분석 기능 구현, 태양 일조 시뮬레이션, 창 최소화 & 저장 기능 (카메라 위치 / 방향)
9월 초 - sample model import, 필터링(검색), 건물 삭제, ctrl 누르고 point 다중 선택 기능
9월 중 - 검색 기능(필터링), 그 외 기능
4) 해야 할 일
상엽 – 좌표 연동 기능 추가, R(x) 구현, ray에 입사각 계산할 수 있는 기능 있는지 검색, projector관련 기능 검색, 드래그 선택 기능 관련 검색
건학 – 창 최소화 & 저장 기능 구현

#기획디자인팀 자체 회의(21.08.17)
210817 기획디자인팀 회의
A.	순서도
-	선재님 -> 내일까지 형식 다듬어서 오네가이시마스
-	지수님 -> 개발팀 물어봐볼게여????!?!?
B.	기능 명세서는 제가 그냥 다 넣을게여
-	24일까지 디자인가이드 – 완성도 높여서
C.	끝

## 회의 진행 노트(6회) 21.08.18 
210818 전체회의
1.	회의일시 : 2021년 8월 18일 22:00 ~
2.	참여자 : 백선재, 김건학, 박상엽, 송치원, 김지수
3.	회의내용
A.	기획디자인팀 보고
-	순서도 끝, 기능명세서와 함께 내일까지 전달드릴게요.
B.	개발팀 보고
-	좌표 연동해서 정보 가져오는 것
-	Non-convex 에셋 쓰면 convex 와 rigidbody 충돌로 일어나는 문제 해결 가능
사각형 까는 것과 에셋 중, 에셋 선택
-	드래그, 컨트롤 누르고 다중 선택에 따른 일조량 정보 계산 구현.
-	저장 관련 논의 – 사용자가 변경한 것 (모델 임포트, 카메라 위치, 모델 수정사항)
C.	기타 논의
-	8월 26일 22:20
D.	끝

#기획디자인팀 자체회의(21.08.25)
210825 기획디자인팀 회의
1.	회의일시 : 2021년 8월 25일 22:00 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의내용
A.	디자인가이드 확인
-   선재님 – 치원 레이아웃 만들면 맞춰서 컴퓨터로 지수님처럼 만들기
-   지수님 – 
-   치원 레이아웃 만들고, 배치화면
B.	개발팀과 논의할 것
-	레이아웃 어떤가요?
-	모의실험 모델 어떻게 할 지
C.	기타
-	다음 회의 : 2021년 8월 31일 22:00 ~
D.	끝


## 회의 진행 노트(7회) 21.08.26
210826 전체회의
1.	회의일시 : 2021년 8월 26일 22:20 ~
2.	참여자 : 박상엽, 백선재, 김건학, 김지수, 송치원
3.	회의내용
A.	기획팀 보고
-	디자인 레이아웃 제작 중.
B.	개발팀 보고
-	Non-convex collider 활용해서 건물 바닥에 붙임
-	태양 시뮬레이션
-	건물 클릭 시 좌표를 통해 정보를 불러올 수는 있는데
오차가 있어서 정확히 받아오지 못함.
gis 와 api 가 만나면서 나타나는 오류라서 찾아봐야함. 로직이 틀린건 아님.
나중에 시연연상 같은거 찍을 때, 정확성이 있는 부분만 보여주는 것으로.
-	Ray 받는 component 를 면으로 만듦. 조금 뚫려보이는 현상이 존재. 면이 겹치면서 
발생하는 현상 같음. 이유를 알 것 같음. 디버깅 시도 해봄. -> 해결!
-	탐색기 유니티꺼(호환문제 x) 쓸지, 시스템꺼 (OS간 호환 문제 예상) 쓸지 – 라이센스 확인 필요
-	아파트 이름 뜨는거는 해보고 없어보이면 제거;;
-	위치랑 로케이션 저장하는 것도 
C.	디자인 외주는 아직 연락이 안옴.
D.	다음 회의 날짜와 다음 할 것
2021년 9월 2일 (목) 22:00 ~
기획팀 – 레이아웃 만들고, 가이드 완성해서 외주든 직접 만들든 그 전까지 준비 완료
		사운드 소스 좀 찾아보기
개발팀 – 건물 삭제, 추가(import), 건물 정보 검색, 건물 일부 선택 구현
E.	개강 다들 화이팅…

#기획디자인팀 자체 회의(21.08.31)
210831 기획디자인팀 회의
1.	회의일시 : 2021년 8월 31일 22:10 ~
2.	참여자 : 송치원, 김지수, 백선재
3.	회의내용

A.	디자인 확인
치원 – 슬라이더랑 날짜설정 만들기

B.	사운드 확인
지수님 – 저작권 확인해서 올려주기
	클릭음 빼고, 지수님 사운드 활용
	추후 더 필요한 상황 발생 시 추가로 구하기

C.	대책 수립 – 디자인 외주 실패
외주 뚫는거 목요일 전까지 (가능한 수요일)
사람을 구한다면? - 1주일
외주 요청 실패 시 -> 구인 성공 여부와 관계없이 작업 시작

D.	기타 논의
선재님 – 외주 물어보고, 안되면 사람 구하기
다음 회의 : 이틀 후에 있는 전체회의 끝나고 정하기


## 회의 진행 노트(8회) 21.09.02
210902 전체회의
1.	회의일자 : 2021년 9월 2일 22:00 ~

2.	참여자 : 박상엽, 김건학, 송치원, 백선재, 김지수

3.	회의내용
A.	기획디자인팀 보고
-	디자인 외주 불가능 판정으로 인해 딜레이
	병가이므로 내일 문의
-	지수님 효과음

B.	개발팀 보고
샘플 모델 – 지붕이나 창문, 틈 없애면 좋음. 이제 1주에 2개 정도 만들 듯! 크기 상관없음 ㅎㅎ
건물 삭제 구현
검색은 1분 정도 걸림. 시간이 너무 오래걸려서 해결해야함
건물 임포트 시 크기 조절과 바닥 붙이는 것 구현. 좌표에 따른 배치? 구현 생각은 안해봄
배치 시에 카메라와 건물 움직인는 법 논의
1)	롤 y키처럼 건물과 카메라가 같이 움직이기 – 조작이 쉬울까?
2)	Wasd 로 카메라, 건물 위치는 드래그
3)	스타처럼 클릭 한번 누르면 커서 계속 따라다니기 – wasd 또는 커서 화면 밖으로 이동해서 카메라 이동
임포트 할 건물 미리보기 – 따라다니면서 미리보기할거면 그냥 애초에 붙이는건 ? 시도해봄
크기조절 – 숫자가 너무 작아서 문제였는데 치환으로 해결하는건? 
Ex) 10^-5 를 a 로 치환, 사용자가 10을 입력하면 10a
	일조량 계산 모드 어떻게? 기본 -> 클릭 -> 계산모드(가칭) 클릭 -> 점 선택 -> 결과
	드래그, 다중선택, 미터별로 건물 분할(표시만)
C.	기타 논의
-	특허출원과 소프트웨어 등록
-	다음 회의 날짜 : 2021년 9월 9일 22:00 ~
-	일조량 점 선택 어떻게 할지 생각나면 말하기^~^!!
-	샘플 모델 카테고리 : 주택, 오피스텔, 원룸, 빌라, 관공서, 병원, 학교, 교회, 절, 아파트, 상가, 대형마트, [운동장, 체육관, 야구장 등등 같은 운동시설], 지상건물주차장, 타워(남산타워같은), 호텔
-	한 주 2~3개 => 10월 중순 (6주차)에 카테고리당 2개 완료

#기획디자인팀 자체 회의록(21.09.07)
210907 기획디자인팀 회의
1.	회의일시 : 2021년 9월 7일 22:00 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의내용
A.	디자인 외주 가능 (킹선재)
-	서류 확인
B.	업체 서치 필요
-	송치원이 후보 알아오기

## 회의 진행 노트(9회) 21.09.02
210909 전체회의
1.	회의일자 : 2021년 9월 9일 22:00 ~
2.	참여자 : 김건학, 박상엽, 백선재, 송치원, 김지수
3.	회의내용
A.	기획팀 보고
1)	선재님과 멘토님 얘기 이미 끝남. 외주가능
2)	업체 선정하면 요구에 맞게 기획 할 예정
B.	개발팀 보고
1)	검색 문제 해결, 건물 배치시에 커서 따리다니는 것도 구현. 드래그 놓으면 건물이 떨어지면서 땅에 붙음.
2)	앞으로 ray 받는 점 필터링 구현할 것.
3)	임포트 한 건물 선택이 안되는 경우가 있음;; - 원인 찾음. 해결 성공
C.	기타논의
1)	모델 카테고리 조정 : 주택, 오피스텔, 빌라, 관공서, 학교, 아파트, 상가건물, 대형마트, 랜드마크, 호텔
주택 4
오피스텔 2 – 다음 주까지 이거 하나씩 해오기
빌라 6
관공서 2
학교 2
아파트 6
상가건물 2
대형마트 2
랜드마크 2
호텔 2
홀짝 나누지 말고, 그냥 나누기 2 해서 모델링
D.	다음 회의 날짜
2021년 9월 16일 오후 10시 ~
	
## 회의 진행 노트(10회) 21.09.16
210916 전체회의
1.	회의일시 : 2021년 9월 16일 22:00 `
2.	참여자 : 송치원, 박상엽, 김지수, 백선재
3.	회의내용
A.	건학님 명절 친척집 방문으로 불참
B.	기획팀 보고
C.	개발팀 보고
-	수정한 건 많은데 티가 안남
-	레이를 받는 점 명칭을 ‘포인트’라 부르기로 함.
-	포인트 선택하는 기능 구현. 드래그와 다중선택은 안함.
-	포인트 선택 시 – Q : 그림판처럼 색칠하는 방법이 좋을지, 드래그하는게 좋을지?
A : 그림판, 드래그 사용자가 선택할 수 있도록
-	리셋버튼도 필요함.
-	단축키 정리
-	모델 임포트 시 건물 크기 최적화 과정에서 오류가 발생
건물 크기를 수정했음에도 불구하고, ray를 못받는 부분이 생겨남
-	개발팀 해야할 일 : 건물을 추가하고 삭제한 상태를 저장하는 기능 구현해아함
D.	기타논의
-	디자인 시 오른쪽 하단에 위도 경도 표시
-	나타낼 일조량 정보 – 일평균, 일최대, 연평균, 연최대, 사용자 입력
(화이트보드 캡쳐사진 참고)
-	import 된 건물 저장방법 논의 : 게임오브젝트 째로 저장, 사용자 파일을 임포트시에 그대로 kmsis 폴더에 복사해서 그걸 import

E.	다음 전체 회의날짜
-	21.09.28 화 22시

#기획디자인팀 자체회의(21.09.27)
210927 기획(디자인)팀 회의

1.	회의일시 : 2021년 9월 27일 월 22:00 ~
2.	참여자 : 백선재, 김지수, 송치원
3.	회의내용
a.	직인 및 결제 관련
-	크몽이 아니라 직접 결제가 가능한지 물어보기
-	가능하다고 하면, 등기 물어보고, 등기 안되면 선재님이 직접 고고
-	등록 완료되면, ‘또’ 선재님이 가서 결제
b.	다음 회의는 내일 끝나고 결정


## 회의 진행 노트(11회) 21.09.28
210928 전체회의
1.	회의일시 : 2021년 9월 28일 22:00 ~
2.	참여자 : 김지수, 김건학, 박상엽, 송치원, 백선재
3.	회의내용
a.	기획팀 보고
-	업체에서 1일(금)까지 등기를 보내준다고 함. 그럼 10월 4,5일 쯤 업체 등록 완료, 세금계산서 수령, 학교 측에 승인 요청, 8일 쯤 승인, 11일부터 작업 시작하면 20일쯤 끝.
b.	개발팀 보고
-	버그 수정, 포인트는 그림판 모드 또는 네모로 선택 구현
-	문제점 1) 포인트 분석하는 시간이 너무 오래 걸림. 
	한 건물을 선택했을 때, 연 일조량을 나오게 하는 것은 불가능함.
	최대로 선택할 수 있는 포인트 갯수를 줄이는 것은 – 중대건물 한 면 정도?
	일단 3~4개월 정도로 계산할 수 있는 일자를 제한한 뒤, 최적화 정도에 따라 후일 늘리던가 함.
	예상 계산시간을 보여주자. 함부로 선택할 수 없도록.
-	문제점 2) 게임오브젝트 전체 저장 후 불러오기 – 직렬화의 불가능으로 이 방식은 실패 (유니티에서 지원 x)
대체 할만한 방안은 잘 안보임. 
근데 찾음 ㅋㅋ 폴더 안에 모델 파일을 복사해서 나중에 호출 시 임포트. 스케일이나 로테이션 값은 저장 가능.
c.	기타 논의
1)	단축키 – 오 이거 만듦 ㅎㅎ;;
2)	와이어프레임 – 일단 기획서 전달, 더 필요하거나 궁금한거 있으면 요청.
3)	다음 회의 일자 : 10월 5일 22:00 ~

## 회의 진행 노트(12회) 21.10.05
211005 전체회의

1.	회의일시 : 2021년 10월 5일 22:00 ~
2.	참여자 : 송치원, 박상엽, 김지수, 백선재, 김건학
3.	회의내용
a.	기획디자인팀 보고
-	새로운 업체를 찾음. 작업 중. 10일 걸린다고 함. 부포 55만.
-	와이어프레임 만들어드릴게요 ㅎㅎ;ㅠㅠ
b.	개발팀 보고
-	최적화는 준비만 함.
-	Import 한 건물 저장 문제 없음.
-	단축키 수정함.
-	버그 발견 : 건물 저장하고 다시 불러올 때 건물 순서가 바뀌는 버그가 있음.
c.	기타 논의
1)	다음 회의 날짜
-	일단 10월 12일 예정, 회의할 것 없으면 취소. => 중간고사 이후 집결
2)	캡쳐사진
-	시뮬 두개, 검색해서 위치 이동 하나, 분석 하나

### 회의 진행 노트(13회) 21.10.28
211028 전체회의

1.	회의일자 : 2021년 10월 28일 22:00 ~
2.	참여자 : 백선재, 박상엽, 김지수, 송치원
3.	회의내용
		
		a.	기획팀 보고
		
		- 계산기간입력, 정보수정요청, 일조량 확인 설정 후 디자인 함. 제플린 올림
                
		- 일조량 확인 부분에 추가할 것

		: 영역선택 버튼, 영역이랑 기간 설정 후 계산실행 버튼 및 예상 소요시간


		- 일조량 확인 설정 후에 추가할 것


		- 저장버튼 위치, 클릭하면 노란색 변하는거 같이 전달

		- 타임슬라이더 재생버튼이랑 시간 위치 좋아보이는 곳으로 수정

		- 광고란 디자인이요,,,


b. 개발팀 보고
		- 최적화를 하고 정확도를 포기 vs 최적화 안하고 정확도를 선택
	
		- 후자로 했을 때, 나타나는 화면은? – 정확도로 갑니다
		
			1) 버퍼링
			
			2) 팁 – 편의점 가는 중입니다…
		
			3) 퍼센트
		
			4) 광고란 – 평생 보지 않기 버튼 만들고 틀린 그림 찾기?!
	
		- 날짜 설정 드롭다운만 하얀색 괜찮?

c. 기타 논의
	
	1) 국가의 부름으로 인한… 건학님 부재 ㅠ
	
	2) 도움말은 깃허브 리드미, 영상은 유튜브 링크 or 준비중입니다.
	
	3) 선재님, 지수님 광고 이미지 찾아오기
	
	4) 다음 회의 11월 4일, 11월11일
	
	5) 11월 6일 회식 - 횟집 가쥬아아앙

### 회의 진행 노트(14회) 21.11.03
211103 전체회의 

1.	참여자 : 송치원, 박상엽, 백선재, 김지수

2.	회의일시 : 2021년 11월 3일 22:00 ~

3.	회의내용

	a.	기획디자인팀 보고
	
		1) 디자인했던 것들 제플린에 올림, 로고 디자인 완성
		
		2) 카메라 줌 슬라이더 박스 – 보내드림
		
		3) 건물선택 화면 앨범형, 텍스트형 디자인 해주세여
		
			-	건물마다 사진이랑 이름 정리해서 보내주세여
	
		4) 시간 설정 후에 저장버튼 있는 사진 제플린에 올려주세요,,,
	
		5) 일평균 일최고 저장을 없앤다 -> 저장기록까지 수정해야함. 일평균, 일최고 화면에 저장버튼도 없애야함.
	
		6) 오전 오후 설정 삭제

	
	b.	개발팀 보고
	
		1) 도움말, 정보수정요청 링크 연결
		
		2) 버튼 UI (카메라 컨트롤러 등), 저장기록 UI 구현
		
		3) 코드 수정

	
	c.	기타 논의

		1) 다음 회의 : 11월 10일 (수) 22:00
		
		2) 회식 : 11월 5일 (금) 18:00 종로 3가 ~



### 회의 진행 노트(15회) 21.11.10
211110 전체회의

	1. 회의일자 : 2021년 11월 10일 22:00 ~
	
	2. 참여자 : 송치원, 박상엽, 백선재, (김지수)
	
	3. 회의내용	
	
		a. 기획디자인팀 보고
			
			1) 저장기록, 건물선택 디자인 – 제플린에 올림
			
			2) 멘토님 특허 관련 설명 문서 전달드림
			
			3) 모델파일이랑 사진 보내드렸는데, 사진 크기가 조금씩 달라요. 그 사진들 조금씩 좌우로 늘리거나 해도 보기에 안이상하니까, 개발할 때 참고해주세요. 하다가 너무 이상				   하면 다시 캡쳐해서 보내드리겠습니다.
			
			4) 영역 선택할 때 화면이 바뀌면 좋겠음 (영역 선택중입니다… 라든지) – 테두리 색칠
			
			5) 저장버튼 누르면 저장완료 -> 서브텍스트 배경에 체크표시 하나 만들어서 드림.
	
		b. 개발팀 보고
			
			1) 타임패널 날짜 선택 – 완료 NO
			
			2) 타임패널 시뮬레이션 재생 / 일시정지 - 완료
			
			3) 건물배치 설정 - 완료
			
			4) 로고 변경 - 완료
			
			5) 설정 평균 / 최고 일조량 계산 기간 설정 - 완료
			
			6) 설정 평균 / 최고 일조량 계산 영역 설정 - 완료
			
			7) 설정 평균 / 최고 일조량 계산 - 완료
			
			8) 기록 저장 & 저장기록 열람
			
			9) 일조량 확인 시 이미지 광고 패널
			
			10) 건물배치패널 앨범형 / 텍스트형 건물 목록
			
			11) 아이콘패널 컬러 조절
			
			12) 카메라 회전 & 리셋 & 줌 컨트롤러
			
			13) 검색어 저장
			
			14) 최근 검색어 클릭시 같은 검색어로 다시 검색 / 최근 검색어 기록 삭제

		c.	기타 논의



### 회의 진행 노트(16회) 21.11.14
211114 전체회의 
	
	1. 회의일시 : 2021년 11월 14일 11:00 ~
	
	2. 참여자 : 박상엽, 김지수, 백선재, 송치원
	
	3. 회의내용
	
		A. 데드라인 체크를 위한 회의라는 것을 감안함. 보고의 의미는 크게 없음
		
		B. 개발팀 
		
			1) 타임패널 날짜 선택 – 완료 NO
		
			2) 타임패널 시뮬레이션 재생 / 일시정지 - 완료
			
			3) 건물배치 설정 - 완료
			
			4) 로고 변경 - 완료
			
			5) 설정 평균 / 최고 일조량 계산 기간 설정 - 완료
			
			6) 설정 평균 / 최고 일조량 계산 영역 설정 - 완료
			
			7) 설정 평균 / 최고 일조량 계산 – 완료
			
			--------------------------- 저번 회의 까지 -----------------------------
			
			8) 기록 저장 & 저장기록 열람 – 완료
			
			9) 일조량 확인 시 이미지 광고 패널 – 완료
			
			10) 건물배치패널 앨범형 / 텍스트형 건물 목록 - 완료
			
			11) 아이콘패널 컬러 조절 – 완료
			
			12) 카메라 회전 & 리셋 & 줌 컨트롤러 – 완료
			
			13) 검색어 저장 – 완료
			
			14) 최근 검색어 클릭시 같은 검색어로 다시 검색 / 최근 검색어 기록 삭제 – 완료
			    - 앞으로 자잘한 버그들 고칠 예정
		
		C. 기타 논의
			1) 다음 회의 : 2021년 11월 17일 오후 10시 – 특별한 안건 없을 시 취소
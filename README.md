## 🤘서비스 주제

메타버스 회의 룸 APP서비스 구현

</br>

## 📜 서비스 내용

**VR기기가 따로 필요하지 않고 마이크 기능과 채팅기능**을 통해 화상 회의를 가능하게 하는 앱 서비스입니다.

</br>

현재 위 서비스에서 제공하는 핵심 기능 3가지입니다.

1. 화상회의를 모바일 형태로 진행이 가능하다.
2. 각 사용자 마다 Unique함을 제공하기 위해 캐릭터 스타일을 지정할 수 있다.
3. 웹 엑스와 줌과 다르게 양방향 소통이 더욱더 자연스럽다.

</br>

## 🛠 기술 스택

- Unity, Photon Server
- C#, Mysql

</br>

## 🖥 개발 내용

### 1. 가상 방을 생성하여 최대 20명까지 참여가능한 소통장 생성

- 유니티 환경에서 Photon Server를 사용하여 로그인 후 접속을 했을때, 접속한 다양한 사용자들이 Master서버에 접속 후 로비, 집, 방, 병원 등 다양한 소통 공간에 Join할 수 있는 기능을 구현하였다.


### 2. 사용자들끼리 소통할 수 있는 채팅 기능 구현

- Photon Chat Server를 사용하여 사용자별로 채팅을 하면서 소통장에서 자신의 의견을 공유 할 수 있는 기능을 구현하였다.


### 3. 사용자들끼리 소통할 수 있는 보이스톡 기능 구현

- Photon Voice Server를 사용하여 보이스톡을 이용해 다양한 사용자들과 자신의 의견을 공유 할 수 있는 기능을 구현하였다.


### 4. 전체적인 디자인

- 소통 공간 디자인 및 개발

</br>

## 👀 서비스 화면

<서비스 출시>
https://play.google.com/store/apps/details?id=com.BeHappy.LittleMetaVillage


|               배포 APP 서비스            |               회원가입 및 로그인            |
| :---------------------------------:   |    :-------------------------------:   |
| <img src="https://user-images.githubusercontent.com/64251951/215010955-73873cb5-1015-4a44-80df-62dd44d6711c.png" width="500" height="450"/>|<img src="https://user-images.githubusercontent.com/64251951/215011090-6ca921ae-19df-4b7d-b379-4fcba65d3569.png" width="500" height="450"/>
|               로그인 후 로비              |              회의 룸 장소                 |
| <img src="https://user-images.githubusercontent.com/64251951/215010955-73873cb5-1015-4a44-80df-62dd44d6711c.png" width="500" height="450"/>|<img src="https://user-images.githubusercontent.com/64251951/215011340-985d7dd6-927e-4a9e-b4ee-c0ce2e24e741.png" width="500" height="450"/>


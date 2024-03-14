# UGRP_traffic_light_demo

![](/image/america_trafficlight.png)

![](/image/korea_trafficlight.png)

DGIST UGRP 활동 중 만든 신호등 체계를 구현한 Asset의 demo 프로그램입니다.

## Table

- [UGRP\_traffic\_light\_demo](#ugrp_traffic_light_demo)
  - [Table](#table)
  - [사용법](#사용법)
  - [구현 방법](#구현-방법)
    - [사용된 Asset](#사용된-asset)
    - [Scripts](#scripts)

## 사용법

`UGRP_trafficlight.exe`를 실행한 뒤에, 카메라를 다음과 같이 움직일 수 있습니다. 

- WASD: 수평 상하좌우 이동
- 위쪽 화살표, 아래쪽 화살표: 수직 이동
- 왼쪽 화살표, 오른쪽 화살표: 좌우 카메라 회전

또한, 구현된 네 개의 신호등 체계를 보려면 숫자 1, 2, 3, 4를 누르면 됩니다.

- 1: 미국 신호등
- 2: 대한민국 신호등 - 직진 후 좌회전
- 3: 대한민국 신호등 - 직좌 동시신호(동시 정지 신호가 있는 경우)
- 4: 대한민국 신호등 - 직좌 동시신호(동시 정지 신호가 없는 경우)

## 구현 방법

### 사용된 Asset

Unity를 이용해 구현했으며, Unity Asset Store의 다음 Asset들을 활용했습니다.

- [Animating Traffic Lights / Street Lamps / Signs](https://assetstore.unity.com/packages/3d/props/exterior/animating-traffic-lights-street-lamps-signs-149530): 신호등의 기본적인 외형에 사용됨
- [Deluxe Primitives](https://assetstore.unity.com/packages/3d/props/deluxe-primitives-10769): 표지판을 만들 때 사용
- [Urban Traffic System Full Pack](https://assetstore.unity.com/packages/templates/systems/urban-traffic-system-full-pack-166688): 사거리를 만들 때 사용

### Scripts

이외의 신호등 Logic이나 신호 주기 등은 [Scripts](/Scripts/)에 있는 스크립트를 이용해 구현했습니다.

- [LightStateGenerator_V2.cs](/Scripts/LightStateGenerator_V2.cs): 신호 주기를 생성합니다. 신호 주기는 대한민국 신호등을 기준으로 만들어졌으며, 다음 신호 주기들이 구현되었습니다.
  - 직진 후 좌회전
  - 직좌 동시신호 - 전체 정지 신호가 없는 경우
  - 직좌 동시신호 - 전체 정지 신호가 있는 경우
  - 비보호 좌회전 - 전체 정지 신호가 없는 경우
  - 비보호 좌회전 - 전체 정지 신호가 있는 경우
  - 보행자 신호등
  - 우회전 신호등
- [TrafficLightControllerV2.cs](/Scripts/TrafficLightControllerV2.cs): 신호등 체계의 전반적인 동작을 맡습니다. `LightStateGenerator_V2.cs`에서 신호 주기를 받아 신호등 체계 속 신호등들을 초기화하고, 신호 주기에 맞춰서 신호등을 동작시킵니다.
- [traffic_light_UGRP.cs](/Scripts/traffic_light_UGRP.cs): 기본 신호등 class입니다. `new_york_carLight.cs`를 제외한 신호등들은 이 class를 상속받습니다.
  - [car_light_UGRP.cs](/Scripts/car_light_UGRP.cs): 대한민국 차량 신호등의 동작에 필요한 변수들이 추가되었습니다
  - [ped_light_UGRP.cs](/Scripts/ped_light_UGRP.cs): 보행자 신호등의 동작에 필요한 변수들이 추가되었습니다.
  - [rightTurn_light_UGRP.cs](/Scripts/rightTurn_light_UGRP.cs): 우회전 신호등의 동작에 필요한 변수들이 추가되었습니다.
- [new_york_carLight.cs](/Scripts/new_york_carLight.cs): 대한민국 신호등에 맞춰진 신호 주기를 미국 신호등에 적용하기 위해 따로 만든 스크립트입니다. `traffic_light_UGRP.cs`의 동작을 그대로 모방합니다. 지금 생각해보면 overriding을 하면 되지 않았나 싶긴 합니다.
- [maincameraController.cs](/Scripts/maincameraController.cs): demo 프로그램에서 카메라의 움직임을 담당합니다
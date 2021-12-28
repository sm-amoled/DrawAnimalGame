/* 
    Track 생성의 Rule

    트랙을 둘러쌓고있는 Empty gameObject는 position (0,0,0) rotation (0,0,0), scale (0,0,0)을 만족해야한다.
    
    트랙은 tag 와 layer를 'track'으로 설정해야한다.
        position은 (*, -5, *)으로 설정한다.
    
    spawnPoint의 position은 (*, -4.3, *)으로 설정한다.
    trackEndPoint의 position은 (*, -4.5, *)으로 설정한다.
            tag는 'trackEnd'로 설정한다.
 */
for /l %%x in (1, 1, 10000) do (
	echo %%x
	start D:\RobotsProject\raisim_workspace\UnitySkeletonGeneratorEXE\UnitySkeletonGeneratorEXE.exe
	timeout /t 20 /nobreak>nul
	taskkill /f /im UnitySkeletonGeneratorEXE.exe
)
# -*- coding:utf-8 -*-
# @Time      : 2022-01-01
# @Author    : ZedMoster1@gmail.com

import time
import shutil
import os


def copy_search_file(srcDir, desDir):
    ls = os.listdir(srcDir)
    for li in ls:
        filePath = os.path.join(srcDir, li)
        if not os.path.exists(desDir):
            os.makedirs(desDir)
        if os.path.isfile(filePath):
            try:
                shutil.copy(filePath, desDir)
            except Exception as e:
                print(f"异常:{e}")


if __name__ == '__main__':
    version = [2021]
    for ver in version:
        # dll
        copyPath = os.path.join(os.getcwd(), "CsharpDemo\\bin\\Debug")
        newPath = f"C:\ProgramData\Autodesk\Revit\Addins\{ver}\Debug"
        copy_search_file(copyPath, newPath)
        # addin
        copyPath = os.path.join(os.getcwd(), "CsharpDemo\\bin\\CsharpDemo.addin")
        addinPath = f"C:\ProgramData\Autodesk\Revit\Addins\{ver}\CsharpDemo.addin"
        shutil.copy(copyPath, addinPath)
        print(f"已复制:{ver}")
    time.sleep(1.2)

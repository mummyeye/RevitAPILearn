# -*- coding:utf-8 -*-

from PIL import Image
import os
import time


class IImage:
    def __init__(self, folder=None):
        self._folder = folder if folder else os.getcwd()

    @staticmethod
    def _get_file_path(path):
        files = os.listdir(path)
        _myList = dict()
        for file_name in files:
            name, ty = os.path.splitext(file_name)
            new_file_name = "{}_16{}".format(name, ty)
            if new_file_name not in files and "_16" not in file_name and "_355" not in file_name and ty == ".png":
                _myList[file_name] = new_file_name

        return _myList

    @staticmethod
    def _half_png_size(infile, outfile, size=0.5):
        im = Image.open(infile)
        (x, y) = im.size
        out = im.resize((int(x * size), int(y * size)))
        out.save(outfile, "png")

    def main(self):
        _myList = self._get_file_path(self._folder)
        if _myList:
            print(_myList)
            for i in _myList:
                infile = os.path.join(self._folder, i)
                outfile = os.path.join(self._folder, _myList[i])
                self._half_png_size(infile, outfile)
        else:
            print("no work")


if __name__ == '__main__':
    filepath = os.path.join(os.getcwd(), "Icon")
    IImage = IImage(filepath)
    IImage.main()
    time.sleep(1.2)
    
